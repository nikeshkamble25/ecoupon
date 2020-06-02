FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS Build
WORKDIR /ecoupon/api
COPY . .
RUN dotnet restore
RUN dotnet build
RUN dotnet publish -c release

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=Build /ecoupon/api/ecoupon.api/bin/Release/netcoreapp3.1/publish/ ./
ENV ASPNETCORE_URLS http://*:5000
EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "ecoupon.api.dll"]