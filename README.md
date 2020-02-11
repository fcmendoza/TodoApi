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

## Vehicle API

Sample request:

```sh
curl -ksv GET https://localhost:5001/api/Vehicle/ABC123 | jq
```

Should give us something like the following:

```sh
> GET /api/Vehicle/ABC123 HTTP/1.1
> Host: localhost:5001
> User-Agent: curl/7.54.0
> Accept: */*
>
< HTTP/1.1 200 OK
< Date: Mon, 27 Jan 2020 19:44:42 GMT
< Content-Type: application/json; charset=utf-8
< Server: Kestrel
< Transfer-Encoding: chunked
<
{ [293 bytes data]
* Connection #1 to host localhost left intact
{
  "vin": "ABC123",
  "profile": null,
  "hasDelivery": false,
  "vehicleType": 0,
  "make": "Tesla",
  "year": 0,
  "hourlyRate": 0,
  "isAvailable": false,
  "millage": 0,
  "rating": 0,
  "numberOfSeats": 0,
  "transmissionType": 0,
  "greenType": 0,
  "longitude": 0,
  "latitude": 0,
  "features": null,
  "categories": null,
  "color": {},
  "tags": null
}
```

### Vehicle and Price

```sh
curl -k GET https://localhost:5001/api/Vehicle/Price/ABC123 | jq
```

Response:

```sh
  % Total    % Received % Xferd  Average Speed   Time    Time     Time  Current
                                 Dload  Upload   Total   Spent    Left  Speed
  0     0    0     0    0     0      0      0 --:--:-- --:--:-- --:--:--     0curl: (6) Could not resolve host: GET
100   386    0   386    0     0    189      0 --:--:--  0:00:02 --:--:--   210
{
  "vehicle": {
    "vin": "ABC123",
    "host": null,
    "profile": null,
    "hasDelivery": false,
    "vehicleType": 0,
    "make": "Tesla",
    "model": "Model X",
    "year": 0,
    "hourlyRate": 0,
    "isAvailable": false,
    "millage": 0,
    "rating": 0,
    "numberOfSeats": 0,
    "transmissionType": 0,
    "greenType": 0,
    "longitude": 0,
    "latitude": 0,
    "features": null,
    "categories": null,
    "color": {},
    "tags": null
  },
  "price": {
    "make": "Tesla",
    "model": "Model X",
    "price": 149.5
  }
}
```

# Build and Run a Docker Image

## Prerequisites

* Docker
* .NET Core (e.g.: _.NET Core 3.1 for MacOS_: https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.100-macos-x64-installer)

## Build and run

From the project's directory run the following commads:

```sh
# Downloads all the requirements from Docker and creates a new image. This will take a while the first time it's ran. This can take a few minutes the first time.
docker build -t todoapi .

# Creates a new container and runs it. The app runs inside the container on port 80 and we're mapping it to the host machine's port 8080
docker run -d -p 8080:80 --name myapp todoapi

# You should get something like the following back:
# 8931c5cdfc273b70b47a3336de29cadac64c592d808a4ad523658e1266fe6800

# Running the following command should display the just created image:
docker container ls

# The result will look something like this:
# CONTAINER ID        IMAGE               COMMAND                CREATED             STATUS              PORTS                  NAMES
# 8931c5cdfc27        todoapi             "dotnet TodoApi.dll"   2 hours ago         Up 2 hours          0.0.0.0:8080->80/tcp   myapp
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