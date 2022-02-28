#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["IdentityTEST/CoreERP.UI.csproj", "IdentityTEST/"]
COPY ["CoreERP.Model/CoreERP.Model.csproj", "CoreERP.Model/"]
RUN dotnet restore "IdentityTEST/CoreERP.UI.csproj"
COPY . .
WORKDIR "/src/IdentityTEST"
RUN dotnet build "CoreERP.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoreERP.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoreERP.UI.dll"]