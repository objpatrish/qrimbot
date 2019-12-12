FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env

WORKDIR /app

COPY ./src/*.csproj ./
RUN dotnet restore

COPY ./src ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app

COPY --from=build-env /app/out .

VOLUME [ "/media" ]

ENTRYPOINT ["dotnet", "objpatrishbot.dll"]