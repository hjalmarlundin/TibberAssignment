FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /source

COPY Cleaner.Hosting/*.csproj Cleaner.Hosting/
COPY Cleaner.Application/*.csproj Cleaner.Application/
COPY Cleaner.Repository/*.csproj Cleaner.Repository/

RUN dotnet restore Cleaner.Hosting/Cleaner.Hosting.csproj

# copy and publish app and libraries
COPY Cleaner.Hosting/. Cleaner.Hosting/
COPY Cleaner.Application/. Cleaner.Application/
COPY Cleaner.Repository/. Cleaner.Repository/

RUN dotnet publish Cleaner.Hosting/Cleaner.Hosting.csproj -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["./Cleaner.Hosting"]