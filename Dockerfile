# -------------------------------
# Build Stage
# -------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Restore dependencies
RUN dotnet restore

# Publish the project
RUN dotnet publish -c Release -o /app/publish

# -------------------------------
# Runtime Stage
# -------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Expose port (Render uses 8080)
EXPOSE 8080

# Copy published build
COPY --from=build /app/publish .

# Start the app
ENTRYPOINT ["dotnet", "YasserWorkShop.dll"]
