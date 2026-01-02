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

# Copy database files if they exist (using RUN with cp to handle missing files gracefully)
RUN --mount=type=bind,from=build,source=/src/civ5hype,target=/tmp/source \
    cp /tmp/source/*.db* ./ 2>/dev/null || echo "No database files found - will be created on first run"

# Expose port - Railway provides PORT env variable
ENV ASPNETCORE_URLS=http://+:${PORT:-5000}

ENTRYPOINT ["dotnet", "civ5hype.dll"]

