# JwtGenerator

This is a Web Application for generate JWT Tokens

- :heavy_check_mark: **.NET 8**
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

# Deploy manually to heroku as container

Note: Github actions will deploy automatically to heroku staging as container when push new commits to branch `master`

[Deploying .NET Core to Heroku](https://dev.to/alrobilliard/deploying-net-core-to-heroku-1lfe)

- `heroku login`
- `heroku container:login`
- `cd JwtGenerator` (to go into the same folder that `JwtGenerator.sln` file)
- `docker build -t jwt-generator-2022 .`
- `heroku container:push -a jwt-generator-2022 web`
- `heroku container:release -a jwt-generator-2022 web`
