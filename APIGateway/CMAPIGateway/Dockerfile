#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["APIGateway/CMAPIGateway/CMAPIGateway.csproj", "APIGateway/CMAPIGateway/"]
RUN dotnet restore "APIGateway/CMAPIGateway/CMAPIGateway.csproj"
COPY . .
WORKDIR "/src/APIGateway/CMAPIGateway"
RUN dotnet build "CMAPIGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CMAPIGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CMAPIGateway.dll"]