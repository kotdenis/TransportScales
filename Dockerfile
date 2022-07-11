#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ./TransportScales.sln ./
COPY ./TransportScales.Api/TransportScales.Api.csproj ./TransportScales.Api/
COPY ./TransportScales.Core/TransportScales.Core.csproj ./TransportScales.Core/
COPY ./TransportScales.Dto/TransportScales.Dto.csproj ./TransportScales.Dto/
COPY ./TransportScales.Data/TransportScales.Data.csproj ./TransportScales.Data/
RUN dotnet restore ./TransportScales.Api/TransportScales.Api.csproj
COPY . .
WORKDIR "/src/TransportScales.Api"
RUN dotnet build "TransportScales.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TransportScales.Api.csproj" -c Release -o /app/publish 

HEALTHCHECK --interval=30s --timeout=5s --start-period=20s --retries=3 CMD [ "curl -f http://localhost/health/liveness || exit 1" ]

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TransportScales.Api.dll"]