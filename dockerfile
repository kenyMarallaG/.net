FROM mcr.microsoft.com/dotnet/nightly/sdk:6.0.100-preview.7 as build
WORKDIR /app
COPY . .
RUN dotnet build "prueba.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "prueba.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "prueba.dll"]

