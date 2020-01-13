#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Speedruns.Web/Speedruns.Web.csproj", "Speedruns.Web/"]
COPY ["Streamers.PlatformIntegration/Streamers.PlatformIntegration.csproj", "Streamers.PlatformIntegration/"]
RUN dotnet restore "Speedruns.Web/Speedruns.Web.csproj"
COPY . .
WORKDIR "/src/Speedruns.Web"
RUN dotnet build "Speedruns.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Speedruns.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Speedruns.Web.dll"]