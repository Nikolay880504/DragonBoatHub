FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build 

WORKDIR /src

COPY src/Client/Telegram/*.csproj Client/Telegram/
COPY src/Contracts/*.csproj Contracts/

RUN dotnet restore Client/Telegram/DragonBot.csproj

COPY . .

RUN dotnet publish  src/Client/Telegram/DragonBot.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80

COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DragonBot.dll"]