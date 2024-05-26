FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Service.Core/MeteorFlow.Core.Api/MeteorFlow.Core.Api.csproj", "Service.Core/MeteorFlow.Core.Api/"]
RUN dotnet restore "Service.Core/MeteorFlow.Core.Api/MeteorFlow.Core.Api.csproj"
COPY . .
WORKDIR "/src/Service.Core/MeteorFlow.Core.Api"
RUN dotnet build "MeteorFlow.Core.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MeteorFlow.Core.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeteorFlow.Core.Api.dll"]
