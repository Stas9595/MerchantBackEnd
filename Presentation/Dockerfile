FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app
COPY . ./
RUN dotnet restore "Presentation/Presentation.csproj"
RUN dotnet publish -c Release -o output /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
COPY --from=build /app/output .
ENTRYPOINT ["dotnet", "Presentation.dll"]
