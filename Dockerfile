# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY civ5hype/civ5hype.csproj civ5hype/
RUN dotnet restore civ5hype/civ5hype.csproj

# Copy everything else and build
COPY civ5hype/ civ5hype/
WORKDIR /src/civ5hype
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/publish .

# Copy database if exists
COPY civ5hype/civ5hype.db* ./

# Expose port
ENV ASPNETCORE_URLS=http://+:$PORT
EXPOSE $PORT

ENTRYPOINT ["dotnet", "civ5hype.dll"]

