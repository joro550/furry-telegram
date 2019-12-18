#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Speedruns.Web/Server/Speedruns.Web.Server.csproj", "Speedruns.Web/Server/"]
COPY ["Speedruns.Web/Shared/Speedruns.Web.Shared.csproj", "Speedruns.Web/Shared/"]
COPY ["Speedruns.Web/Client/Speedruns.Web.Client.csproj", "Speedruns.Web/Client/"]
RUN dotnet restore "Speedruns.Web/Server/Speedruns.Web.Server.csproj"
COPY . .
WORKDIR "/src/Speedruns.Web/Server"
RUN dotnet build "Speedruns.Web.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Speedruns.Web.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Speedruns.Web.Server.dll"]