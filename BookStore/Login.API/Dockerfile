#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS baseapilogin
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS buildapilogin
WORKDIR /src
COPY ["Login.API\Login.API.csproj", "Login.API/"]
RUN dotnet restore "Login.API\Login.API.csproj"
COPY . .
WORKDIR "/src/Login.API"
RUN dotnet build "Login.API.csproj" -c Release -o /app/build

FROM buildapilogin AS publish
RUN dotnet publish "Login.API.csproj" -c Release -o /app/publish

FROM baseapilogin AS finalapi
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Login.API.dll"]