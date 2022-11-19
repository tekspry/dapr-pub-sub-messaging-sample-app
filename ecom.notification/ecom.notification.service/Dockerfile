#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ecom.notification/ecom.notification.service/ecom.notification.service.csproj", "ecom.notification/ecom.notification.service/"]
RUN dotnet restore "ecom.notification/ecom.notification.service/ecom.notification.service.csproj"
COPY . .
WORKDIR "/src/ecom.notification/ecom.notification.service"
RUN dotnet build "ecom.notification.service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ecom.notification.service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ecom.notification.service.dll"]