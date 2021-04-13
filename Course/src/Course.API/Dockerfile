#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Course/Course.API/Course.API.csproj", "Course/Course.API/"]
RUN dotnet restore "Course/Course.API/Course.API.csproj"
COPY . .
WORKDIR "/src/Course/Course.API"
RUN dotnet build "Course.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Course.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Course.API.dll"]