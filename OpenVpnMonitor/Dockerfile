FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OpenVpnMonitor/OpenVpnMonitor.csproj", "OpenVpnMonitor/"]
RUN dotnet restore "OpenVpnMonitor/OpenVpnMonitor.csproj"
COPY . .
WORKDIR "/src/OpenVpnMonitor"
RUN dotnet build "OpenVpnMonitor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenVpnMonitor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenVpnMonitor.dll"]
