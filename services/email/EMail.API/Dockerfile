#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["services/email/EMail.API/EMail.API.csproj", "services/email/EMail.API/"]
COPY ["services/email/EMail.Application/EMail.Application.csproj", "services/email/EMail.Application/"]
COPY ["services/email/EMail.Domain/EMail.Domain.csproj", "services/email/EMail.Domain/"]
COPY ["services/email/EMail.Infrastructure/EMail.Infrastructure.csproj", "services/email/EMail.Infrastructure/"]
RUN dotnet restore "services/email/EMail.API/EMail.API.csproj"
COPY . .
WORKDIR "/src/services/email/EMail.API"
RUN dotnet build "EMail.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EMail.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EMail.API.dll"]
