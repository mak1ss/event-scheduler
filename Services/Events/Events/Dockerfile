#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Events/Events/Events.WEBAPI.csproj", "Services/Events/Events/"]
COPY ["Services/Events/Events.BLL/Events.BLL.csproj", "Services/Events/Events.BLL/"]
COPY ["Services/Events/Events.DAL/Events.DAL.csproj", "Services/Events/Events.DAL/"]
RUN dotnet restore "./Services/Events/Events/./Events.WEBAPI.csproj"
COPY . .
WORKDIR "/src/Services/Events/Events"
RUN dotnet build "./Events.WEBAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Events.WEBAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Events.WEBAPI.dll"]