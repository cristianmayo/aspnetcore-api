# ASP.NET-Core Web API Template
Repository template for Web API using ASP.NET Core.


## Development Technologies, Tools, and Strategy
This repository template is dedicated for stand-alone Web API project that could serve as a Restful Web API service and/or reusable library through dependency injection. 

### Development Technologies
Below are the list of primary technologies used in this repository template:
>- ASP.NET Core Web API
>- NSwag.AspNetCore
>- Nuke.Build
>- Docker

### Development Tools
Below are _preferred_ development tools to use and running as administrator:
>- Visual Studio IDE
>- PowerShell
>- Developer Command Prompt

### Development Strategy
Follow the link below for the details of the development strategies implemented in the repository template:
>- Documenting API with Swagger UI
>- Generating Client and Contract with NukeBuild and NSwag


## Contribution Guideline
Should you want to contribute in the development of this repository template, please follow below guideline (as much as possible). 

### Branching Model
I am new to this development strategy but with few months of dabbling, I have used two (2) branching model. **_Trunk-based Development_** is what I preferred to use when creating reusable repositories with local development setup and for packaged libraries, I preferred to use _GitFlow_. 

Use the following code-branch naming convention:
>- Feature: `feature/{{github_username}}_short-feature-description`
>- Bug-fix: `bugfix/{{github_username}}_short-fix-description`
>- Hot-fix: `hotfix/{{github_username}}_short-fix-description`
