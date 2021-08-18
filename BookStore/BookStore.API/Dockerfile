#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS baseapi
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS buildapi
WORKDIR /src
RUN git clone -b master https://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:x-oauth-basic@github.com/ritamghosh81/DotNetCoreSampleBookApp.git /src
WORKDIR "/src/BookStore/BookStore.API"
RUN dotnet build "BookStore.API.csproj" -c Release -o /app/build

FROM buildapi AS publish
RUN dotnet publish "BookStore.API.csproj" -c Release -o /app/publish

FROM baseapi AS finalapi
WORKDIR /app
COPY --from=publish /app/publish .
RUN chmod +x /app/BookStore.API
ENTRYPOINT ["/app/BookStore.API"]
CMD ["--urls","http://0.0.0.0:80"]
