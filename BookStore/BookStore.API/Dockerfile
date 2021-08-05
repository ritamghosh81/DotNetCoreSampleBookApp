#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS baseapi
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS buildapi
WORKDIR /src
COPY ["BookStore.API\BookStore.API.csproj", "BookStore.API/"]
RUN dotnet restore "BookStore.API\BookStore.API.csproj"
COPY . .
WORKDIR "/src/BookStore.API"
RUN dotnet build "BookStore.API.csproj" -c Release -o /app/build

FROM buildapi AS publish
RUN dotnet publish "BookStore.API.csproj" -c Release -o /app/publish

FROM baseapi AS finalapi
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStore.API.dll"]