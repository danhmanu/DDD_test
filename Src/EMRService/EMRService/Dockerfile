# 1. Base image để chạy ứng dụng ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000  # Mở cổng 5000 cho HTTP

# 2. SDK image để build ứng dụng
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Sao chép file .csproj vào container
COPY EMRService.csproj ./
RUN dotnet restore

# Sao chép toàn bộ mã nguồn
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# 3. Final image chỉ để chạy app
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EMRService.dll"]
