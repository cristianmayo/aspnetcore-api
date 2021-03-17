FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY [".", "/app"]
ENTRYPOINT ["dotnet", "AspNetCore.API.dll"]