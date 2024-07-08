### Build Stage ###
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY src/HowsYourDayApp/HowsYourDayApp.csproj src/HowsYourDayApp/
COPY src/Shared/Shared.csproj src/Shared/

RUN dotnet restore src/HowsYourDayApp/HowsYourDayApp.csproj

COPY . .

WORKDIR /src/src/HowsYourDayApp

RUN dotnet build -c Release -o /app/build

### Publish Stage ###
FROM build as publish

RUN dotnet publish -c Release -o /app/publish

### Runtime Stage ###
FROM nginx:alpine AS final

WORKDIR /usr/share/nginx/html

COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
EXPOSE 81
