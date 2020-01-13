# Run the Application Locally

## Prerequisites

* .NET Core (e.g.: _.NET Core 3.1 for MacOS_: https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.100-macos-x64-installer)

## Build and run

From the project's directory run:

```sh
dotnet run
```

You should see an output like the following:

```sh
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /Users/jdoe/projects/TodoApi
```

Make a request to verify the application is working:

```sh
# Use cURL with -k option which allows curl to make insecure connections, that is cURL does not verify the certificate
curl -k GET https://localhost:5001/WeatherForecast
```

You should get something like the following as a response:

```json
[{"date":"2020-01-14T04:16:07.276236+00:00","temperatureC":20,"temperatureF":67,"summary":"Balmy"},{"date":"2020-01-15T04:16:07.2762576+00:00","temperatureC":27,"temperatureF":80,"summary":"Warm"},{"date":"2020-01-16T04:16:07.2762723+00:00","temperatureC":9,"temperatureF":48,"summary":"Cool"},{"date":"2020-01-17T04:16:07.2762875+00:00","temperatureC":-12,"temperatureF":11,"summary":"Balmy"},{"date":"2020-01-18T04:16:07.2763012+00:00","temperatureC":45,"temperatureF":112,"summary":"Balmy"}]
```

# Build and Run a Docker Image

## Prerequisites

* Docker
* .NET Core (e.g.: _.NET Core 3.1 for MacOS_: https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.100-macos-x64-installer)

## Build and run

From the project's directory run the following commads:

```sh
# Downloads all the requirements from Docker and creates a new image. This will take a while the first time it's ran.
docker build -t todoapi .

# Creates a new container and runs it. The app runs inside the container on port 80 and we're mapping it to the host machine's port 8080
docker run -d -p 8080:80 --name myapp todoapi
```

Make a sample request to verify the application is running:

```sh
curl -X GET http://localhost:8080/WeatherForecast
```

You should get a JSON array as a response.

# Resources

* [Create a Web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.1&tabs=visual-studio-code)
* [Dockerize an ASP.NET Core application](https://docs.docker.com/engine/examples/dotnetcore/)
* [Beginning .NET Core development with docker on Linux, Part 1](https://itnext.io/beginning-net-core-development-with-docker-on-linux-6595a7eebdaa)