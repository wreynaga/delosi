#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DelosiWebApi/DelosiWebApi.csproj", "DelosiWebApi/"]
COPY ["Delosi.Application.Interface/Delosi.Application.Interface.csproj", "Delosi.Application.Interface/"]
COPY ["Delosi.Application.DTO/Delosi.Application.DTO.csproj", "Delosi.Application.DTO/"]
COPY ["Delosi.Transversal.Common/Delosi.Transversal.Common.csproj", "Delosi.Transversal.Common/"]
COPY ["Delosi.Application.Main/Delosi.Application.Main.csproj", "Delosi.Application.Main/"]
COPY ["Delosi.Application.Validator/Delosi.Application.Validator.csproj", "Delosi.Application.Validator/"]
COPY ["Delosi.Domain.Interface/Delosi.Domain.Interface.csproj", "Delosi.Domain.Interface/"]
COPY ["Delosi.Domain.Entity/Delosi.Domain.Entity.csproj", "Delosi.Domain.Entity/"]
COPY ["Delosi.Domain.Core/Delosi.Domain.Core.csproj", "Delosi.Domain.Core/"]
COPY ["Delosi.Infrastructure.Interface/Delosi.Infrastructure.Interface.csproj", "Delosi.Infrastructure.Interface/"]
COPY ["Delosi.Infrastructure.Data/Delosi.Infrastructure.Data.csproj", "Delosi.Infrastructure.Data/"]
COPY ["Delosi.Infrastructure.Repository/Delosi.Infrastructure.Repository.csproj", "Delosi.Infrastructure.Repository/"]
COPY ["Delosi.Transversal.Logging/Delosi.Transversal.Logging.csproj", "Delosi.Transversal.Logging/"]
COPY ["Delosi.Transversal.Mapper/Delosi.Transversal.Mapper.csproj", "Delosi.Transversal.Mapper/"]
RUN dotnet restore "DelosiWebApi/DelosiWebApi.csproj"
COPY . .
WORKDIR "/src/DelosiWebApi"
RUN dotnet build "DelosiWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DelosiWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DelosiWebApi.dll"]