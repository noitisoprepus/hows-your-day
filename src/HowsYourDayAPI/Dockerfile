### Build Stage ###
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY src/HowsYourDayAPI/HowsYourDayAPI.csproj src/HowsYourDayAPI/
COPY src/Shared/Shared.csproj src/Shared/

RUN dotnet restore src/HowsYourDayAPI/HowsYourDayAPI.csproj

COPY . .

WORKDIR /src/src/HowsYourDayAPI

RUN dotnet build -c Release -o /app/build

### Publish Stage ###
FROM build as publish

RUN dotnet publish -c Release -o /app/publish

### Runtime Stage ###
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=publish /app/publish .

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["dotnet", "HowsYourDayAPI.dll"]
