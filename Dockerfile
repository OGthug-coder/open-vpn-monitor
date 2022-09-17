FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OpenVpnMonitor.WorkerService/OpenVpnMonitor.WorkerService.csproj", "OpenVpnMonitor.WorkerService/"]
RUN dotnet restore "OpenVpnMonitor.WorkerService/OpenVpnMonitor.WorkerService.csproj"
COPY . .
WORKDIR "/src/OpenVpnMonitor.WorkerService"
RUN dotnet build "OpenVpnMonitor.WorkerService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenVpnMonitor.WorkerService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenVpnMonitor.WorkerService.dll"]
