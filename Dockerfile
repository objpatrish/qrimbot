FROM microsoft/dotnet:sdk
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore

COPY ./src ./
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:dotnercore-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "objpatrishbot.dll"]