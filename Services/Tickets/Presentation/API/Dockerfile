#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Tickets/Presentation/API/API.csproj", "Services/Tickets/Presentation/API/"]
COPY ["Services/Tickets/Core/Application/Application.csproj", "Services/Tickets/Core/Application/"]
COPY ["Services/Tickets/Infrastructure/Persistence/Persistence.csproj", "Services/Tickets/Infrastructure/Persistence/"]
COPY ["Services/Tickets/Core/Domain/Domain.csproj", "Services/Tickets/Core/Domain/"]
RUN dotnet restore "./Services/Tickets/Presentation/API/./API.csproj"
COPY . .
WORKDIR "/src/Services/Tickets/Presentation/API"
RUN dotnet build "./API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]