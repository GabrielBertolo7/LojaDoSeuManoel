# Etapa 1: imagem base para rodar o app
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

# Etapa 2: imagem para build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copia arquivos de projeto (csproj) primeiro, para aproveitar cache
COPY LojaDoSeuManoel.sln .
COPY LojaSeuManoel.API/LojaSeuManoel.API.csproj LojaSeuManoel.API/
COPY LojaSeuManoel.Core/LojaSeuManoel.Core.csproj LojaSeuManoel.Core/
COPY LojaSeuManoel.Infra/LojaSeuManoel.Infra.csproj LojaSeuManoel.Infra/

# Restaura pacotes
RUN dotnet restore

# Copia o restante dos arquivos
COPY . .

# Publica a aplicação com configuração de Release
RUN dotnet publish LojaSeuManoel.API/LojaSeuManoel.API.csproj -c Release -o /app/publish

# Etapa 3: imagem final que roda a app publicada12e
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

# Executa a API
ENTRYPOINT ["dotnet", "LojaSeuManoel.API.dll"]
