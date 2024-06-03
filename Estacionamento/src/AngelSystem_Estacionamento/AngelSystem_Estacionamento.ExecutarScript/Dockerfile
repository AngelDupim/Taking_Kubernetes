FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY . ./

RUN dotnet publish "src/AngelSystem_Estacionamento/AngelSystem_Estacionamento.ExecutarScript" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
COPY ["src/AngelSystem_Estacionamento/AngelSystem_Estacionamento.ExecutarScript/ScriptsSql/SqlServer.sql", "ScriptsSql/SqlServer.sql"]
COPY ["src/AngelSystem_Estacionamento/AngelSystem_Estacionamento.ExecutarScript/ScriptsSql/SqlServer-Database.sql", "ScriptsSql/SqlServer-Database.sql"]

ENTRYPOINT ["dotnet", "AngelSystem_Estacionamento.ExecutarScript.dll"]

