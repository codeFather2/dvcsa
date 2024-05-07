# Use the official ASP.NET Core SDK image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Set the working directory in the container
WORKDIR /app
COPY dvcsa.csproj .
# Restore NuGet packages
RUN dotnet restore dvcsa.csproj

COPY . .

RUN dotnet dev-certs https --trust

# Build the application
ENTRYPOINT ["dotnet"]
CMD ["watch", "--project" , "dvcsa.csproj",  "run", "--","--project" , "dvcsa.csproj"]
