# Pull the full SDK for building
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

#Pull the runtime for packaging
FROM  mcr.microsoft.com/dotnet/aspnet:6.0 
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "AccountManagementService.dll" ]