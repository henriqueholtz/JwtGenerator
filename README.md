# JwtGenerator

This is a Web Application for generate JWT Tokens

- :heavy_check_mark: **dotnet 5**
- :heavy_check_mark: **Swagger**
- :heavy_check_mark: **Dockerfile (Linux)**
- :heavy_check_mark: **Docker-compose (to Heroku)**

# How to run the application from CLI ?

- `dotnet dev-certs https`
- `dotnet run --project JwtGenerator/JwtGenerator.csproj --trust`

# How to run tests of integration with newman (localhost) ?

- install `newman` => `npm install -g newman`
- run => `newman run JWTGenerator.postman_collection.json --global-var="JwtGenerator=https://localhost:5001/api" --insecure`

# How to view or edit the collection of requests ?

- You can view/edit using the [Postman Collection Explorer extension](https://marketplace.visualstudio.com/items?itemName=MrCodingB.postman-collection-explorer) in Visual Studio Code
