#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["StudentCourse/src/StudentCourse.API/StudentCourse.API.csproj", "StudentCourse/src/StudentCourse.API/"]
RUN dotnet restore "StudentCourse/src/StudentCourse.API/StudentCourse.API.csproj"
COPY . .
WORKDIR "/src/StudentCourse/src/StudentCourse.API"
RUN dotnet build "StudentCourse.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StudentCourse.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StudentCourse.API.dll"]