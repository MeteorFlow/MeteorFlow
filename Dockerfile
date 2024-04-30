FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
ARG configuration=Release

WORKDIR /src
COPY src .

RUN dotnet publish -c $configuration --property:PublishDir=/src/published

# =====================================================================================

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
USER app
WORKDIR /app
COPY --from=publish /src/published .

EXPOSE 8080

ENTRYPOINT [ "dotnet", "MeteorFlow.Web.dll" ]