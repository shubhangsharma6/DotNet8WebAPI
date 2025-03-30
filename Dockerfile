# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./DotNet8WebAPI/DotNet8WebAPI.csproj", "DotNet8WebAPI/"]
RUN dotnet restore "DotNet8WebAPI/DotNet8WebAPI.csproj"
COPY . .
WORKDIR "/src/DotNet8WebAPI"
RUN dotnet build "./DotNet8WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DotNet8WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNet8WebAPI.dll"]

#For browsing the api locally through docker
#Open Docker Desktop locally
#Open powershell on the path where the dockerfile exist
#Run the command -  docker build -t donet8webapi .
#then run the command  - docker run -p 8080:8080 donet8webapi
#browse - http://192.168.1.4:8080/swagger/index.html in local browser