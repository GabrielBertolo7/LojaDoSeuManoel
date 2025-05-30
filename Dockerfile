FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY LojaDoSeuManoel.sln .
COPY LojaSeuManoel.API/LojaSeuManoel.API.csproj LojaSeuManoel.API/
COPY LojaSeuManoel.Core/LojaSeuManoel.Core.csproj LojaSeuManoel.Core/
COPY LojaSeuManoel.Infra/LojaSeuManoel.Infra.csproj LojaSeuManoel.Infra/

RUN dotnet restore

COPY . .

RUN dotnet publish LojaSeuManoel.API/LojaSeuManoel.API.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "LojaSeuManoel.API.dll"]
