FROM mcr.microsoft.com/dotnet/core/sdk:3.1

#instal sqlite libs
RUN apt-get -y update
RUN apt-get -y upgrade
RUN apt-get install -y sqlite3 libsqlite3-dev

RUN dotnet tool install --global dotnet-ef
ENV PATH="${PATH}:/root/.dotnet/tools"