FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build-env
WORKDIR /app

COPY ./*.sln .
COPY ./Ellegia.WebApi/*.csproj ./Ellegia.WebApi/
COPY ./Ellegia.Infra.Data/*.csproj ./Ellegia.Infra.Data/
COPY ./Ellegia.Infra.CrossCutting.IoC/*.csproj ./Ellegia.Infra.CrossCutting.IoC/
COPY ./Ellegia.Infra.CrossCutting.Identity/*.csproj ./Ellegia.Infra.CrossCutting.Identity/
COPY ./Ellegia.Domain.Core/*.csproj ./Ellegia.Domain.Core/
COPY ./Ellegia.Domain/*.csproj ./Ellegia.Domain/
COPY ./Ellegia.Application/*.csproj ./Ellegia.Application/

RUN dotnet restore

COPY ./Ellegia.WebApi/. ./Ellegia.WebApi/
COPY ./Ellegia.Infra.Data/. ./Ellegia.Infra.Data/
COPY ./Ellegia.Infra.CrossCutting.IoC/. ./Ellegia.Infra.CrossCutting.IoC/
COPY ./Ellegia.Infra.CrossCutting.Identity/. ./Ellegia.Infra.CrossCutting.Identity/
COPY ./Ellegia.Domain.Core/. ./Ellegia.Domain.Core/
COPY ./Ellegia.Domain/. ./Ellegia.Domain/
COPY ./Ellegia.Application/. ./Ellegia.Application/

RUN dotnet publish ./Ellegia.WebApi/Ellegia.WebApi.csproj -c Release -o out
COPY ./Ellegia.WebApi/appsettings.json ./Ellegia.WebApi/out/

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS runtime-env
WORKDIR /app
COPY --from=build-env /app/Ellegia.WebApi/out .
ENTRYPOINT ["dotnet", "Ellegia.WebApi.dll"]