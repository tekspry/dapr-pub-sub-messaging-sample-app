#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ecom.payment/ecom.payment.service/ecom.payment.service.csproj", "ecom.payment/ecom.payment.service/"]
RUN dotnet restore "ecom.payment/ecom.payment.service/ecom.payment.service.csproj"
COPY . .
WORKDIR "/src/ecom.payment/ecom.payment.service"
RUN dotnet build "ecom.payment.service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ecom.payment.service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ecom.payment.service.dll"]