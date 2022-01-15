#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=https://+:8080
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Mijn stem Back/MijnStemBack.csproj", "Mijn stem Back/"]
RUN dotnet restore "Mijn stem Back/MijnStemBack.csproj"
COPY . .
WORKDIR "/src/Mijn stem Back"
RUN dotnet build "MijnStemBack.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MijnStemBack.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MijnStemBack.dll"]
