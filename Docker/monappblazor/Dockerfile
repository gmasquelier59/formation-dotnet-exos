FROM mcr.microsoft.com/dotnet/aspnet AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /src
COPY ["monappblazor.csproj","."]
RUN dotnet restore "monappblazor.csproj"
COPY . .

RUN dotnet build "monappblazor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "monappblazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet","monappblazor.dll"]


# construire l'image
# Ouvrir un terminal a la racine du projet (ou se trouve le dockerfile)
# docker build -t blazor-chouchou .

# test de l'image
# docker run -d --name chouchou-blazor -p 5006:8080 blazor-chouchou
# http://localhost:5006/