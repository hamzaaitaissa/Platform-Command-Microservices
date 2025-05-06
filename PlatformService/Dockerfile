#Hey Docker — start with a .NET 8 SDK box where I can build and compile code
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
#Go inside a folder called /app — that’s where we’ll work
WORKDIR /app

#Bring in the .csproj file (project file) from my PC into the Docker box because we want to restore NuGet packages next
COPY *.csproj ./
#Download and install all the NuGet packages the project needs
RUN dotnet restore

#Okay now bring in everything else (all source code, files, etc
COPY . ./
#Now compile everything in Release mode and put the output (published app) inside a folder called /app/out
RUN dotnet publish -c Release -o out

#Now give me a tiny ASP.NET Core Runtime box — no need for SDK anymore it only runs apps, it doesn't build them
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
#Take the compiled app from the build box (/app/out) and put it here
COPY --from=build-env /app/out .
#When someone runs this Docker container automatically start the app by running: dotnet PlatformService.dll
ENTRYPOINT [ "dotnet", "PlatformService.dll" ]