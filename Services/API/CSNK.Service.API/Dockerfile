#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/API/CSNK.Service.API/CSNK.Service.API.csproj", "Services/API/CSNK.Service.API/"]

COPY ["Common/CSNK.Common.Base/CSNK.Common.Base.csproj", "Common/CSNK.Common.Base/"]

COPY ["Services/Features/CSNK.Services.Features.Customer/CSNK.Services.Features.Customer.csproj", "Services/Features/CSNK.Services.Features.Customer/"]

RUN dotnet restore "Services/API/CSNK.Service.API/CSNK.Service.API.csproj"
COPY . .

WORKDIR "/src/Services/API/CSNK.Service.API"
RUN dotnet build "CSNK.Service.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSNK.Service.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENV ASPNETCORE_URLS http://*:5002
ENTRYPOINT ["dotnet", "CSNK.Service.API.dll"]
