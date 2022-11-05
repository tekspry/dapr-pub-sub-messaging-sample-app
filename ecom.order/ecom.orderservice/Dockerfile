#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ecom.order/ecom.orderservice/ecom.orderservice.csproj", "ecom.order/ecom.orderservice/"]
RUN dotnet restore "ecom.order/ecom.orderservice/ecom.orderservice.csproj"
COPY . .
WORKDIR "/src/ecom.order/ecom.orderservice"
RUN dotnet build "ecom.orderservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ecom.orderservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ecom.orderservice.dll"]