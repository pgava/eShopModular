FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/eShopModular.Api.csproj", "Api/"]
COPY ["Application/eShopModular.Application.csproj", "Application/"]
COPY ["Domain/eShopModular.Domain.csproj", "Domain/"]
COPY ["Infrastructure/eShopModular.Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "Api/eShopModular.Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "eShopModular.Api.csproj" -o /app/build

FROM build AS publish
RUN dotnet publish "eShopModular.Api.csproj" -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "eShopModular.Api.dll"]
