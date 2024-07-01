#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Gestran.VehicleControl.Api/Gestran.VehicleControl.Api.csproj", "Gestran.VehicleControl.Api/"]
COPY ["Gestran.VehicleControl.Infra/Gestran.VehicleControl.Infra.csproj", "Gestran.VehicleControl.Infra/"]
COPY ["Gestran.VehicleControl.Domain/Gestran.VehicleControl.Domain.csproj", "Gestran.VehicleControl.Domain/"]
RUN dotnet restore "./Gestran.VehicleControl.Api/Gestran.VehicleControl.Api.csproj"
COPY . .
WORKDIR "/src/Gestran.VehicleControl.Api"
RUN dotnet build "./Gestran.VehicleControl.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Gestran.VehicleControl.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gestran.VehicleControl.Api.dll"]