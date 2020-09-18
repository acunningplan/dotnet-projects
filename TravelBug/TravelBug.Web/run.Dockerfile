#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster
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
RUN dotnet build
CMD [ "dotnet", "run" ]