FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/API/*.csproj API/
COPY src/Application/*.csproj Application/
COPY src/Domain/*.csproj Domain/
COPY src/Infrastructure/*.csproj Infrastructure/
COPY src/Contracts/*.csproj Contracts/

RUN dotnet restore API/DragonBoatHub.API.csproj

COPY . .

RUN dotnet publish src/API/DragonBoatHub.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DragonBoatHub.API.dll"]


