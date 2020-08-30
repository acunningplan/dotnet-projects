#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

ENV travel_bug_token_key=travel_bug_secret

RUN apt-get update -y
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash --debug
RUN apt-get install nodejs -yq

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src

RUN apt-get update -y
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash --debug
RUN apt-get install nodejs -yq


COPY ["TravelBug/TravelBug.Web.csproj", "TravelBug/"]
COPY ["TravelBug.Infrastructure/TravelBug.Infrastructure.csproj", "TravelBug.Infrastructure/"]
COPY ["TravelBug.Context/TravelBug.Context.csproj", "TravelBug.Context/"]
COPY ["TravelBug.Entities/TravelBug.Entities.csproj", "TravelBug.Entities/"]
COPY ["TravelBug.Services/TravelBug.CrudServices.csproj", "TravelBug.Services/"]
COPY ["TravelBug.PhotoServices/TravelBug.PhotoServices.csproj", "TravelBug.PhotoServices/"]
COPY ["TravelBug.FollowingServices/TravelBug.FollowingServices.csproj", "TravelBug.FollowingServices/"]
RUN dotnet restore "TravelBug/TravelBug.Web.csproj"
COPY . .
WORKDIR "/src/TravelBug"
RUN dotnet build "TravelBug.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelBug.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelBug.Web.dll"]