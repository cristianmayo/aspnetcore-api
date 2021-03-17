<div style="margin-bottom:2em;">

# **AspNetCore.API Template**

Repository template for Web API using ASP.NET Framework which aims to create a reusable repository template including technologies, tools, and strategies to jumpstart a development of Restful Web API service and extended API Client library.

### **Technologies**
>- ASP.NET Web API Framework | [ASP.NET > APIs](https://dotnet.microsoft.com/apps/aspnet/apis)
>- NukeBuild | [nuke-build/nuke](https://github.com/nuke-build/nuke)
>- NSwag | [RicoSuter/NSwag](http://nswag.org/)

</div>
<div style="margin-bottom:5em;">

### **Project Folder Structure**

    |-- build
    |     \-- _build (NukeBuild)
    |      \
    |       \-- dockerfiles
    |        \    \-- .dockerignore
    |         \    \-- Dockerfile
    |          \
    |           \-- pipelines
    |                 \-- azure-pipelines_build-development.yml
    |                  \-- azure-pipelines_build-feature.yml
    |                   \-- azure-pipelines_build-fixes.yml
    |
    |-- docs
    |     \-- *All related documentations (readme, license, etc.)
    |
    |-- src
    |      \-- AspNetCore.API (API)
    |       \-- AspNetCore.API.Core (Library)
    |        \-- AspNetCore.API.Infrastructure (Library)
    |         \-- AspNetCore.API.RestClient (Library)
    |
    |-- tests
    |     \-- AspNetCore.API.Tests.Integration
    |      \-- AspNetCore.API.Tests.Unit

</div>

<div style="margin-bottom:5em;">

## **Contribution Guideline**

<p style="margin-bottom:2em;">

### **Branching Strategy**

    Trunk-based Development

This branching model was chosen to use for managing development code branches in order to have linear history of all changes implemented from feature branches. 

Should you want to collaborate in the development of this repository template, post a new discussion to let me know and follow the below guideline (as much as possible)

</p>
<p style="margin-bottom:2em;">

### **Code-branch Naming Convention**

Branch | Format
--- | ---
Features | `feature/{{github-username}}/{{short-feature-description}}`
Bug-fixes | `bugfix/{{github-username}}/{{short-fix-description}}`
Hot-fixes | `hotfix/{{github-username}}/{{short-fix-description}}`

</p>
</div>
