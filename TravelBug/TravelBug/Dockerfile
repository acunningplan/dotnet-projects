#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

RUN apt-get update -y
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash --debug
RUN apt-get install nodejs -yq

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src


COPY ["TravelBug/TravelBug.Web.csproj", "TravelBug/"]
COPY ["TravelBug.BusinessLogic/TravelBug.BusinessLogic.csproj", "TravelBug.BusinessLogic/"]
COPY ["TravelBug.Context/TravelBug.Context.csproj", "TravelBug.Context/"]
COPY ["TravelBug.Entities/TravelBug.Entities.csproj", "TravelBug.Entities/"]
COPY ["TravelBug.Services/TravelBug.CrudServices.csproj", "TravelBug.Services/"]
RUN dotnet restore "TravelBug/TravelBug.Web.csproj"
COPY . .
WORKDIR "/src/TravelBug"
RUN dotnet build "TravelBug.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelBug.Web.csproj" -c Release -o /app/publish

RUN apt-get update -y
RUN curl -sL https://deb.nodesource.com/setup_10.x | bash --debug
RUN apt-get install nodejs -yq

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelBug.Web.dll"]