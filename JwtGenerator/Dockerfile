
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . .
# RUN dotnet dev-certs https
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
# ENV ASPNETCORE_URLS="https://+:443;http://+:80"
# ENV ASPNETCORE_HTTPS_PORT="5001"
EXPOSE 80
# EXPOSE 443
COPY --from=build-env /app/out .

# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
# ENTRYPOINT [ "dotnet", "JwtGenerator.dll" ]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet JwtGenerator.dll