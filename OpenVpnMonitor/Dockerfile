FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["open-vpn-monitor/open-vpn-monitor.csproj", "open-vpn-monitor/"]
RUN dotnet restore "open-vpn-monitor/open-vpn-monitor.csproj"
COPY . .
WORKDIR "/src/open-vpn-monitor"
RUN dotnet build "open-vpn-monitor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "open-vpn-monitor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "open-vpn-monitor.dll"]
