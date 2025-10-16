FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/Admin/*.csproj Admin/

RUN dotnet restore Admin/DragonBoatHub.Admin.csproj

COPY . .

RUN dotnet publish src/Admin/DragonBoatHub.Admin.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DragonBoatHub.Admin.dll"]



