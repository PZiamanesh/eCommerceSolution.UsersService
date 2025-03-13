#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["eCommerce.API/UsersMicroService.API.csproj", "eCommerce.API/"]
COPY ["eCommerce.Core/UsersMicroService.Core.csproj", "eCommerce.Core/"]
COPY ["eCommerce.Infrastructure/UsersMicroService.Infrastructure.csproj", "eCommerce.Infrastructure/"]
RUN dotnet restore "./eCommerce.API/./UsersMicroService.API.csproj"
COPY . .
WORKDIR "/src/eCommerce.API"
RUN dotnet build "./UsersMicroService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./UsersMicroService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV POSTGRES_HOST=localhost
ENV POSTGRES_USER=postgres
ENV POSTGRES_PASSWORD=admin
ENV POSTGRES_DATABASE=eCommerceUsers
ENV POSTGRES_PORT=5433
ENTRYPOINT ["dotnet", "UsersMicroService.API.dll"]