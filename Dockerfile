FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /source

COPY Cleaner.Hosting/*.csproj Cleaner.Hosting/
COPY Cleaner.Application/*.csproj Cleaner.Application/

RUN dotnet restore Cleaner.Hosting/Cleaner.Hosting.csproj

# copy and publish app and libraries
COPY Cleaner.Hosting/. Cleaner.Hosting/
COPY Cleaner.Application/. Cleaner.Application/

RUN dotnet publish Cleaner.Hosting/Cleaner.Hosting.csproj -o /app


# # copy files for restore
# COPY ./*/*.csproj ./*.sln ./

# # move csproj files to correct directory
# RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

# # restore packages
# RUN dotnet restore /source/TibberAssignment.sln

# # copy rest of source
# COPY . .

# # check .editorconfig settings
# RUN dotnet tool restore
# RUN dotnet format --verify-no-changes

# # build and check code style
# RUN dotnet build /source/TibberAssignment.sln /p:TreatWarningsAsErrors="true"

# # run unit tests
# RUN dotnet test -c Release

# RUN dotnet publish --no-restore -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
USER $APP_UID
ENTRYPOINT ["./Cleaner.Hosting"]