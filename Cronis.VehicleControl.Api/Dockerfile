#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Cronis.VehicleControl.Api/Cronis.VehicleControl.Api.csproj", "Cronis.VehicleControl.Api/"]
COPY ["Cronis.VehicleControl.Infra/Cronis.VehicleControl.Infra.csproj", "Cronis.VehicleControl.Infra/"]
COPY ["Cronis.VehicleControl.Domain/Cronis.VehicleControl.Domain.csproj", "Cronis.VehicleControl.Domain/"]
RUN dotnet restore "./Cronis.VehicleControl.Api/Cronis.VehicleControl.Api.csproj"
COPY . .
WORKDIR "/src/Cronis.VehicleControl.Api"
RUN dotnet build "./Cronis.VehicleControl.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cronis.VehicleControl.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cronis.VehicleControl.Api.dll"]