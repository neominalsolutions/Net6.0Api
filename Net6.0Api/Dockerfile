#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Net6.0Api/Net6.0Api.csproj", "Net6.0Api/"]
COPY ["Articles.Application/Articles.Application.csproj", "Articles.Application/"]
COPY ["Articles.Domain/Articles.Domain.csproj", "Articles.Domain/"]
COPY ["Articles.Core/Articles.Core.csproj", "Articles.Core/"]
COPY ["Articles.Infra/Articles.Infra.csproj", "Articles.Infra/"]
RUN dotnet restore "Net6.0Api/Net6.0Api.csproj"
COPY . .
WORKDIR "/src/Net6.0Api"
RUN dotnet build "Net6.0Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Net6.0Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Net6.0Api.dll"]