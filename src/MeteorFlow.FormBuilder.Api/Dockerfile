FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MeteorFlow.FormBuilder.Api/MeteorFlow.FormBuilder.Api.csproj", "MeteorFlow.FormBuilder.Api/"]
RUN dotnet restore "MeteorFlow.FormBuilder.Api/MeteorFlow.FormBuilder.Api.csproj"
COPY . .
WORKDIR "/src/MeteorFlow.FormBuilder.Api"
RUN dotnet build "MeteorFlow.FormBuilder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MeteorFlow.FormBuilder.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeteorFlow.FormBuilder.Api.dll"]
