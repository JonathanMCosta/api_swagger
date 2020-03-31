FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/API.Application/API.Application.csproj", ""]
RUN dotnet restore "API.Application.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "src/API.Application/API.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "src/API.Application/API.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.Application.dll"]
