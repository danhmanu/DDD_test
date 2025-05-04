#!/bin/sh               # Dòng shebang - thông báo sử dụng trình thông dịch shell mặc định (sh)
set -e                  # Nếu bất kỳ lệnh nào thất bại, script sẽ dừng ngay lập tức

echo "Starting EMRService..."  # In ra thông báo khi container bắt đầu

exec dotnet EMRService.dll     # Chạy ứng dụng .NET (đã publish) và thay thế shell process
