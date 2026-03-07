# Use .NET 8.0 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["RouterManagement/RouterManagement.csproj", "RouterManagement/"]
RUN dotnet restore "RouterManagement/RouterManagement.csproj"
COPY . .
WORKDIR "/src/RouterManagement"
RUN dotnet build "RouterManagement.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RouterManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use .NET 8.0 ASP.NET runtime image for the runtime environment
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RouterManagement.dll"]
