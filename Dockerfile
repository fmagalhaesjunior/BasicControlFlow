# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# SDK build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["src/BasicControlFlow.Web/BasicControlFlow.Web.csproj", "src/BasicControlFlow.Web/"]
COPY ["src/BasicControlFlow.Infrastructure/BasicControlFlow.Infrastructure.csproj", "src/BasicControlFlow.Infrastructure/"]
COPY ["src/BasicControlFlow.Domain/BasicControlFlow.Domain.csproj", "src/BasicControlFlow.Domain/"]
COPY ["src/BasicControlFlow.Application/BasicControlFlow.Application.csproj", "src/BasicControlFlow.Application/"]

RUN dotnet restore "src/BasicControlFlow.Web/BasicControlFlow.Web.csproj"

COPY . .
WORKDIR "/src/src/BasicControlFlow.Web"
RUN dotnet build "BasicControlFlow.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BasicControlFlow.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BasicControlFlow.Web.dll"]
