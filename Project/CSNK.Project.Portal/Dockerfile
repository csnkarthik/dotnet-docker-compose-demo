#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Project/CSNK.Project.Portal/CSNK.Project.Portal.csproj", "Project/CSNK.Project.Portal/"]
COPY ["Services/API/CSNK.Services.API.Proxy/CSNK.Services.API.Proxy.csproj", "Services/API/CSNK.Services.API.Proxy/"]
COPY ["Common/CSNK.Common.Base/CSNK.Common.Base.csproj", "Common/CSNK.Common.Base/"]
RUN dotnet restore "Project/CSNK.Project.Portal/CSNK.Project.Portal.csproj"
COPY . .
WORKDIR "/src/Project/CSNK.Project.Portal"
RUN dotnet build "CSNK.Project.Portal.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CSNK.Project.Portal.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CSNK.Project.Portal.dll"]