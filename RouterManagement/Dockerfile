# Use .NET 10.0 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Install Node.js for Tailwind CSS build
RUN apt-get update && apt-get install -y curl \
    && curl -fsSL https://deb.nodesource.com/setup_20.x | bash - \
    && apt-get install -y nodejs

COPY ["RouterManagement/RouterManagement.csproj", "RouterManagement/"]
RUN dotnet restore "RouterManagement/RouterManagement.csproj"

COPY . .
WORKDIR "/src/RouterManagement"

# Build Tailwind CSS
RUN npm ci
RUN npm run build:css

ARG APP_VERSION=1.0.0
# Build .NET application
RUN dotnet build "RouterManagement.csproj" -c Release -p:Version=${APP_VERSION} -o /app/build

FROM build AS publish
ARG APP_VERSION=1.0.0
RUN dotnet publish "RouterManagement.csproj" -c Release -p:Version=${APP_VERSION} -o /app/publish /p:UseAppHost=false

# Use .NET 10.0 ASP.NET runtime image for the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RouterManagement.dll"]