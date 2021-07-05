# os comandos do docker file servem para compilar por prompt de comando somente nao 
# funciona me modo debug 
# para utilizar em modo debug copie e cole da versao dockfile.original que se encontra no diretorio
# Get Base Image (Full .NET Core SDK)
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env
WORKDIR /app
ENV ASPNETCORE_ENVIRONMENT=”development”

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MetragemCore.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MetragemCore.dll