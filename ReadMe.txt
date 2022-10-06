Prerequisites :  

Get VS 2022 and .NET 6 or latest version of VS and .NET. 
Ensure you have .net sdk installed
Create a Blazor project
Ensure Powershell is installed, comes by default in Windows10 or above

1. Get Docker docker.com
2. Get WSL (Linux) from docker installation prompt
3. Get \https://git-scm.com/download/win
4. Created a git repo https://github.com/kinematic7/StockTrackerApp
	Here is how to clone it
		Code > Code (green) > Clone
		https://github.com/kinematic7/StockTrackerApp.git
5. Once you clone it here is how you can build it from powershell
	C:\Users\nezra\source\repos\StockTrackerApp\StockTrackerApp
		This is where the csproj is
		Go to Powershell
		Type cd "C:\Users\nezra\source\repos\StockTrackerApp\StockTrackerApp"
		Type dotnet build, if success it will say build successful
		Type dotnet run to host the app, go to the browser and see if it's running
		Ctrl+C to stop running

Create a new directory in repos
Clone the app here git clone https://github.com/kinematic7/StockTrackerApp.git
dotnet restore
dotnet build
dotnet run, go to a browser and see if the app is up, if yes you are all set!
Ctrl+C to stop the app


To get SDK: https://dotnet.microsoft.com/en-us/download/visual-studio-sdks
After gettin it type dotnet --info from powershell to see what version of sdk is installed
Depending on your .net version example 3.1 get the right sdk which supports it.

https://dotnet.microsoft.com/en-us/download/dotnet?cid=getdotnetcorecli

Now follow the instructions here: 
https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/docker/building-net-docker-images?view=aspnetcore-6.0

Create a docker file in the sln directory
- Dockerfile is case sensitive
- Also create .dockerignore
------------------------------------------------------------------------------------------------------------------------
Copy the docker file into parent:
Then run ->
docker build -t stocktrackerapp .
docker run -d -p 8080:80 --name stocktracker stocktrackerapp




