# DDD_test

# Tạo lại migrations
dotnet add package Microsoft.EntityFrameworkCore.Design package hỗ trợ tạo migrations

dotnet ef migrations add InitialCreate
dotnet ef database update


# docker-compose
docker-compose.yml nằm o thư mục gốc của project nơi chứa solution file .sln
Dockerfile nằm trong thư mục của project chứa file .csproj
# Chạy docker-compose
docker-compose build --no-cache
docker-compose up --build



# 1. Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

# 2. SDK image to build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything and build
COPY . ./
RUN dotnet publish -c Release -o /app/publish

# 3. Final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "EMRService.dll"]