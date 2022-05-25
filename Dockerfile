#dowload the image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS burning
#WORKDIR /source

WORKDIR /app

# copy csproj and restore as distinct layers
#COPY *.csproj .
COPY ./ ./
WORKDIR /app/AppVentas.Infraestructura.Datos

RUN dotnet restore

# copy and publish app and libraries
#RUN dotnet publish -c release -o /app --no-restore
RUN dotnet publish -c release -o /app/build

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
#FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app

COPY --from=burning  /app/build  ./

EXPOSE 80

ENTRYPOINT [ "dotnet" ,"AppVentas.Infraestructura.API.dll" ]