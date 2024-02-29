FROM httpd AS base
WORKDIR /usr/local/apache2/htdocs
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Exercice03-PizzeriaOnLine.csproj", "."]
RUN dotnet restore "./Exercice03-PizzeriaOnLine.csproj"
COPY . .
#WORKDIR "/src/."
RUN dotnet build "Exercice03-PizzeriaOnLine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Exercice03-PizzeriaOnLine.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /usr/local/apache2/htdocs
COPY --from=publish /app/publish/wwwroot .
