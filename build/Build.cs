using System;
using System.IO;
using Nuke.Common;
using Nuke.Common.Execution;
using Nuke.Common.Git;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tooling;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Nuke.Common.Utilities.Collections;
using Nuke.Docker;
using Nuke.NSwag;
using static Nuke.Common.IO.FileSystemTasks;
using static Nuke.Common.IO.PathConstruction;
using static Nuke.Common.Tools.DotNet.DotNetTasks;
using static Nuke.Docker.DockerTasks;
using static Nuke.NSwag.NSwagTasks;

[CheckBuildProjectConfigurations]
[UnsetVisualStudioEnvironmentVariables]
class Build : NukeBuild
{
    /// <summary>
    /// Support plugins are available for:
    ///   - JetBrains ReSharper        https://nuke.build/resharper
    ///   - JetBrains Rider            https://nuke.build/rider
    ///   - Microsoft VisualStudio     https://nuke.build/visualstudio
    ///   - Microsoft VSCode           https://nuke.build/vscode
    /// </summary>

    public static int Main () => Execute<Build>(x => x.Compile);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    [Solution] readonly Solution Solution;
    [GitRepository] readonly GitRepository GitRepository;
    [GitVersion] readonly GitVersion GitVersion;

    //Must be lowercase
    private string CONTAINER_IMAGE_NAME = "aspnetcore.api.web";

    AbsolutePath SourceDirectory => RootDirectory / "src";
    AbsolutePath TestsDirectory => RootDirectory / "tests";
    AbsolutePath PackageDirectory => RootDirectory / "artifacts/package";
    AbsolutePath PublishDirectory => RootDirectory / "artifacts/publish";
    AbsolutePath DockerFile => RootDirectory / "Dockerfile";

    Target Clean => _ => _
        .Executes(() => {
            SourceDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            TestsDirectory.GlobDirectories("**/bin", "**/obj").ForEach(DeleteDirectory);
            EnsureCleanDirectory(PublishDirectory);
            EnsureCleanDirectory(PackageDirectory);
        });

    Target Restore => _ => _
        .Before(Clean)
        .Executes(() => {
            DotNetRestore(_ => _
                .SetProjectFile(Solution));
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() => {
            DotNetBuild(_ => _
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore());
        });

    Target UpdateClient => _ => _
        .DependsOn(Compile)
        .Executes(() => {
            var nswagRootDirectory = SourceDirectory / "AspNetCore.API.Web";
            NSwagExecuteDocument(x => x
                .SetWorkingDirectory(nswagRootDirectory.ToString())
                .SetInput(nswagRootDirectory.ToString() + "/AspNetCore.API.Web.Client.nswag")
                .SetNSwagRuntime("NetCore31"));
        });

    Target Test => _ => _
        .DependsOn(UpdateClient)
        .Executes(() => {
            DotNetTest(s => s
                .SetProjectFile(Solution)
                .SetConfiguration(Configuration)
                .EnableNoRestore()
                .EnableNoBuild());
        });

    Target Publish => _ => _
        .DependsOn(Test)
        .Executes(() => {
            DotNetPublish(s => s
                .SetProject(Solution)
                .SetConfiguration(Configuration)
                .SetOutput(PublishDirectory)
                .EnableNoRestore());
        });

    Target Pack => _ => _
        .DependsOn(Publish)
        .Executes(() => {
            DotNetPack(s => s
                .SetProject(Solution)
                .SetOutputDirectory(PackageDirectory)
                .SetIncludeSymbols(true)
                .SetConfiguration(Configuration)
                .EnableNoRestore()
                .EnableNoBuild());
        });

    Target BuildDocker => _ => _
        .Executes(() =>
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dockerArtifacts = Path.Combine(PublishDirectory, "docker");

            EnsureExistingDirectory(dockerArtifacts);

            var tagName = $"{CONTAINER_IMAGE_NAME}:{GitVersion.NuGetVersionV2}";

            DockerBuild(s => s.SetFile(DockerFile)
                .AddLabel($"version={GitVersion.NuGetVersionV2}")
                .AddLabel($"branch={GitRepository.Branch}")
                .AddTag(tagName)
                .AddBuildArg($"AssemblyVersion={GitVersion.AssemblySemVer}")
                .AddBuildArg($"FileVersion={GitVersion.AssemblySemFileVer}")
                .AddBuildArg($"InformationalVersion={GitVersion.InformationalVersion}")
                .SetPath(RootDirectory));
        });

    Target DockerRun => _ => _
        .Executes(() =>
        {
            DockerContainerRun(s => s.SetPublish("9000:80")
                .SetImage($"{CONTAINER_IMAGE_NAME}:{GitVersion.NuGetVersionV2}")
                .SetDetach(true)
                .SetName(CONTAINER_IMAGE_NAME)
            );
        });
}
