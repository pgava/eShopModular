FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/EShopModular.Api.csproj", "Api/"]
COPY ["Application/EShopModular.Application.csproj", "Application/"]
COPY ["Domain/EShopModular.Domain.csproj", "Domain/"]
COPY ["Infrastructure/EShopModular.Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "Api/EShopModular.Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "EShopModular.Api.csproj" -o /app/build

FROM build AS publish
RUN dotnet publish "EShopModular.Api.csproj" -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "EShopModular.Api.dll"]
