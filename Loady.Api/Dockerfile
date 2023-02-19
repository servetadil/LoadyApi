#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Loady.Api/Loady.Api.csproj", "Loady.Api/"]
RUN dotnet restore "Loady.Api/Loady.Api.csproj"
COPY . .
WORKDIR "/src/Loady.Api"
RUN dotnet build "Loady.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Loady.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Loady.Api.dll"]