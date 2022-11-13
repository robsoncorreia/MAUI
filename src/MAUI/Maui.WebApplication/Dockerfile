#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Maui.WebApplication/Maui.WebApplication.csproj", "Maui.WebApplication/"]
COPY ["Maui.Entity/Maui.Entity.csproj", "Maui.Entity/"]
COPY ["Maui.Infrastructure/Maui.Infrastructure.csproj", "Maui.Infrastructure/"]
RUN dotnet restore "Maui.WebApplication/Maui.WebApplication.csproj"
COPY . .
WORKDIR "/src/Maui.WebApplication"
RUN dotnet build "Maui.WebApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Maui.WebApplication.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Maui.WebApplication.dll"]