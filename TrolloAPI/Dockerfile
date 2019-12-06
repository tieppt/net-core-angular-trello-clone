FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
EXPOSE 80 5000 5001

# copy csproj and restore as distinct layers
COPY *.sln .
COPY src/Trollo.API/Trollo.API.csproj src/Trollo.API/
COPY src/Trollo.Common/Trollo.Common.csproj src/Trollo.Common/
COPY src/Trollo.Entity/Trollo.Entity.csproj src/Trollo.Entity/
COPY src/Trollo.Identity/Trollo.Identity.csproj src/Trollo.Identity/
RUN dotnet restore

# copy everything else and build app
COPY src/. ./src/
WORKDIR /app
RUN dotnet publish -c Release -o out

# TODO: fix later
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "Trollo.API.dll"]
