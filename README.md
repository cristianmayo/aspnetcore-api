<div style="margin-bottom:2em;">

# **Human Resource Integrated System (HRIS)**
Integrated system for Human Resource management developed using ASP.NET Core 3.1 Frameworks and MongoDB database provider.

</div>
<div style="margin-bottom:5em;">

## **Project Folder Structure**

    |-- build
    |     \-- _build (NukeBuild)
    |
    |-- docs
    |     \-- *All related documentations (diagram, notes, etc.)
    |
    |-- pipelines
    |     \-- azure-pipelines_build-development.yml
    |      \-- azure-pipelines_build-feature.yml
    |       \-- azure-pipelines_build-fixes.yml
    |
    |-- src
    |      \-- AspNetCore.API.Core (Library)
    |       \
    |        \-- FDT.HRIS.WebPortal.Accounting (MVC)
    |         \-- FDT.HRIS.WebPortal.Administration (MVC)
    |          \
    |           \-- FDT.HRIS.WebServices.Accounting (API)
    |            \-- FDT.HRIS.WebServices.Administration (API)
    |             \-- AspNetCore.API (API)
    |              \-- FDT.HRIS.WebServices.Log (API)
    |
    |-- tests
    |     \-- FDT.HRIS.Tests.Integration
    |      \-- FDT.HRIS.Tests.Unit

</div>

<div style="margin-bottom:5em;">

# **Contribution Guideline**

<p style="margin-bottom:2em;">

## **Branching Strategy**

    Trunk-based Development

This branching model was chosen to use for managing development code branches in order to have linear history of all changes implemented from feature branches. Follow the model and the below naming convention as much as possible...

</p>
<p style="margin-bottom:2em;">

## **Code-branch Naming Convention**

Branch | Format
--- | ---
Features | `feature/{{github-username}}/{{short-feature-description}}`
Bug-fixes | `bugfix/{{github-username}}/{{short-fix-description}}`
Hot-fixes | `hotfix/{{github-username}}/{{short-fix-description}}`

</p>
</div>
