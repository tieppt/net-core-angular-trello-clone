FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
EXPOSE 80 5000 5001

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/Trollo.API/Trollo.API.csproj src/Trollo.API/
COPY src/Trollo.API/Trollo.Common.csproj src/Trollo.API/
COPY src/Trollo.API/Trollo.Entity.csproj src/Trollo.API/
COPY src/Trollo.API/Trollo.Identity.csproj src/Trollo.API/
RUN dotnet restore

# copy everything else and build app
COPY src/. ./src/
WORKDIR /app/src
RUN dotnet publish -c Release -o out

# TODO: fix later
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/src/out ./
ENTRYPOINT ["dotnet", "Trollo.API.dll"]
