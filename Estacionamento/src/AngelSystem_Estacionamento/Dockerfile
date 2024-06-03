FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY . ./

RUN dotnet publish "src/AngelSystem_Estacionamento/AngelSystem_Estacionamento.API" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

ENV ASPNETCORE_ENVIRONMENT="Development"

EXPOSE 8080
EXPOSE 443

ENTRYPOINT ["dotnet", "AngelSystem_Estacionamento.API.dll"]