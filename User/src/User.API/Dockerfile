#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["User/src/User.API/User.API.csproj", "User/src/User.API/"]
RUN dotnet restore "User/src/User.API/User.API.csproj"
COPY . .
WORKDIR "/src/User/src/User.API"
RUN dotnet build "User.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.API.dll"]