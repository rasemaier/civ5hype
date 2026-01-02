# Build stage - Use .NET 10 Stable
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY civ5hype/civ5hype.csproj civ5hype/
RUN dotnet restore civ5hype/civ5hype.csproj

# Copy everything else and build
COPY civ5hype/ civ5hype/
WORKDIR /src/civ5hype
RUN dotnet publish -c Release -o /app/publish

# Runtime stage - Use .NET 10 Stable Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app

# Copy published app
COPY --from=build /app/publish .

# Copy database from source (from root of repo) as a template
# Cache bust: 2026-01-02-19:10
COPY civ5hype.db ./civ5hype-template.db

# Expose port - Railway provides PORT env variable
ENV ASPNETCORE_URLS=http://+:${PORT:-5000}

# Copy template DB to working DB on startup (overwrites old DB)
ENTRYPOINT ["/bin/sh", "-c", "cp -f /app/civ5hype-template.db /app/civ5hype.db && dotnet civ5hype.dll"]

