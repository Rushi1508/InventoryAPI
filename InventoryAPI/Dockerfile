FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY InventoryAPI/*.csproj ./InventoryAPI/
RUN dotnet restore InventoryAPI/InventoryAPI.csproj
COPY InventoryAPI/ ./InventoryAPI/
RUN dotnet publish InventoryAPI/InventoryAPI.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 8080
ENTRYPOINT ["dotnet", "InventoryAPI.dll"]