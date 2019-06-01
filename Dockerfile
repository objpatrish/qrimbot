FROM mcr.microsoft.com/dotnet/core/sdk:2.2 as build-env
WORKDIR /app

COPY ./src/*.csproj ./
RUN dotnet restore

COPY ./src ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/runtime:2.2
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "objpatrishbot.dll"]