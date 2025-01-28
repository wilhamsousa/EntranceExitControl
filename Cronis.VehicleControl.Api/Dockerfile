FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Cronis.VehicleControl.Api/Cronis.VehicleControl.Api.csproj", "Cronis.VehicleControl.Api/"]
COPY ["Cronis.VehicleControl.Application/Cronis.VehicleControl.Application.csproj", "Cronis.VehicleControl.Application/"]
COPY ["Cronis.VehicleControl.Domain/Cronis.VehicleControl.Domain.csproj", "Cronis.VehicleControl.Domain/"]
COPY ["Cronis.VehicleControl.Infra/Cronis.VehicleControl.Infra.csproj", "Cronis.VehicleControl.Infra/"]
RUN dotnet restore "Cronis.VehicleControl.Api/Cronis.VehicleControl.Api.csproj"
COPY . .
WORKDIR "/src/Cronis.VehicleControl.Api"
RUN dotnet build "Cronis.VehicleControl.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Cronis.VehicleControl.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8180
EXPOSE 8181

ENV ASPNETCORE_ENVIRONMENT=Production
ENV ASPNETCORE_HTTP_PORTS=8180

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cronis.VehicleControl.Api.dll"]
