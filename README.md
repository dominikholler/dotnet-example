# dotnet-example

Simple playground app to learn about running dotnet applicaiton in containers.

The app was initialized by
```
SDK="mcr.microsoft.com/dotnet/sdk:10.0"
podman run -it --rm -v $PWD:/app -w /app $SDK dotnet new console -n dotnet-example
podman run -it --rm -v $PWD:/app -w /app $SDK dotnet run
```
