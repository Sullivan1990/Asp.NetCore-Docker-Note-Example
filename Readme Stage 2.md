## Spinning up ASP.NET CORE WEB API + SQL Server on Docker (linux container)

### DockerFile

The first step after creating a basic Web API is to geneerate a 'Dockerfile'. This file defines the steps required to build and publish the application.

    # syntax=docker/dockerfile:1.0
    FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
    WORKDIR /app

    #Copy csproj and restore as distinct layers
    COPY *.csproj ./
    RUN dotnet restore

    # Copy everthing else and build
    COPY ./ ./
    RUN dotnet publish -c Release -o out

    # Build runtime image
    FROM mcr.microsoft.com/dotnet/aspnet:5.0
    WORKDIR /app
    COPY --from=build-env /app/out .
    ENTRYPOINT ["dotnet", "aspDocker.dll"]

This file defines the process for building and publishing the files for the web API, then copying the published files over to a new image before the application itself is started.

### Auto migrations 

A new file was created in the Services folder - this is referenced in the startuo class, and will run the latest migration when the application first starts up.

### Updated Docker-Compose

The docker-compose file was updated to include instructions for building the web api - the 'build: ../' section references the dockerfile created earlier.
The 'depends_on: [mssql]' ensures that the SQL Server instance is started first 

    version: "3"
    services:
        mssql:
            image: "mcr.microsoft.com/mssql/server:2019-GA-ubuntu-16.04"
            environment:
                SA_PASSWORD: "abc_1234"
                ACCEPT_EULA: "Y"
            ports: 
                - "1433:1433"
            volumes:
                - sql_data_volume:/var/opt/mssql
        api:
            build: ../
            depends_on: [mssql]
            ports:
                - "8081:80"

    volumes: 
        sql_data_volume:

### Connection string

The connection string in this new multi-app container can simply be the name of the SQL container - 'mssql'

    "Server=mssql;Database=NoteDB;User=sa;Password=abc_1234"

### Running the Docker system

The container system can be spun up using the same command as earlier (from the root of the project):

    docker-compose -f ./Docker/docker-compose.yaml up -d


### Updates

Updates to the code require the 'api' image to be rebuilt, byt default spinning the container up will just use the pre-build image. The command below will re-build the service with the name 'api', the '--build' command forces a rebuild of the specified service

    docker-compose -f ./Docker/docker-compose.yaml up -d --build api



