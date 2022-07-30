#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
#COPY ["Application/Application.API/Application.API.csproj", "Application/Application.API/"]
#COPY ["Service/Application.IService/Application.IService.csproj", "Service/Application.IService/"]
#COPY ["Modules/Application.Entity/Application.Entity.csproj", "Modules/Application.Entity/"]
#COPY ["Util/Application.Util/Application.Util.csproj", "Util/Application.Util/"]
#COPY ["Modules/Application.Model/Application.Model.csproj", "Modules/Application.Model/"]
#COPY ["Service/Application.Service/Application.Service.csproj", "Service/Application.Service/"]
#COPY ["Data/Application.Data.Repository/Application.Data.Repository.csproj", "Data/Application.Data.Repository/"]
#COPY ["Data/Application.Data/Application.Data.csproj", "Data/Application.Data/"]
#COPY ["Data/Application.Data.EF/Application.Data.EF.csproj", "Data/Application.Data.EF/"]
#COPY ["Modules/Application.Mapping/Application.Mapping.csproj", "Modules/Application.Mapping/"]
#COPY ["Busines/Application.IBusines/Application.IBusines.csproj", "Busines/Application.IBusines/"]
#COPY ["Busines/Application.Busines/Application.Busines.csproj", "Busines/Application.Busines/"]
#RUN dotnet restore "Application/Application.API/Application.API.csproj"
COPY . .
#WORKDIR "/src/Application/Application.API"
#RUN dotnet build "Application.API.csproj" -c Release -o /app/build

#FROM build AS publish
#RUN dotnet publish "Application.API.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Application.API.dll"]
