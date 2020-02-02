FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MonsterTrainer/WebApi.csproj", "MonsterTrainer/"]
COPY ["Model/Model.csproj", "Model/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Services/Services.csproj", "Services/"]
RUN dotnet restore "MonsterTrainer/WebApi.csproj"
COPY . .
WORKDIR "/src/MonsterTrainer"
RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]