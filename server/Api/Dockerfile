FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/eShopCmc.Api.csproj", "Api/"]
COPY ["Application/eShopCmc.Application.csproj", "Application/"]
COPY ["Domain/eShopCmc.Domain.csproj", "Domain/"]
COPY ["Infrastructure/eShopCmc.Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "Api/eShopCmc.Api.csproj"
COPY . .
WORKDIR "/src/Api"
RUN dotnet build "eShopCmc.Api.csproj" -o /app/build

FROM build AS publish
RUN dotnet publish "eShopCmc.Api.csproj" -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "eShopCmc.Api.dll"]
