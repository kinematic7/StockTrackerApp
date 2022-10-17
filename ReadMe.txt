Prerequisites :  
---------------

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

Build and Run Application in Docker:
-----------------------------------
Copy the docker file into parent folder, same as sln file from proj file
Then run ->
docker build -t stocktrackerapp .  (you can do something like stocktrackerapp:latest to give it a tag)
docker run -d -p 8080:80 --name stocktracker stocktrackerapp
------------------------------------------------------------------------------------------------------------------------

PUSH and PULL to Docker Hub:
-----------------------------

Create an account in docker.com
Create a repo, https://hub.docker.com/
Go to Docker Desktop and see what the name of the image is, in our case it's stocktrackerapp:latest
Go powershell:
PS C:\Users\nezra\source\repos\StockTrackerApp> docker tag stocktrackerapp:latest nezraal/net6repo
PS C:\Users\nezra\source\repos\StockTrackerApp> docker push nezraal/net6repo
PS C:\Users\nezra\source\repos\StockTrackerApp> docker pull nezraal/net6repo:latest  

-------------------------------------------------------------------------------------------------------------------------

Other useful commands
---------------------

PS C:\Users\nezra\source\repos\stocktrackerapp> docker start stocktracker
stocktracker
PS C:\Users\nezra\source\repos\stocktrackerapp> docker stop stocktracker
stocktracker

Note this is not the name of the image or the tag. This is the container name.
If you go to docker desktop use the Container name column (not the image column)

docker ps

Gives a list of the images which are actively running on docker

docker rename container-name new-name

This will rename you container name.



--------------------------------------------------------------------------------------------------------------------------

docker exec

Go inside docker shell:

docker exec -it stocktracker sh
This goes to the linux shell
# exit
This exits the shell


Some usage example:
# ls - gets a list of files and directory
# cd <directory name> - goes inside a directory
# cd .. go up in the directory
# cat appsettings.Development.json - see what's in the jason file

https://www.digitalocean.com/community/tutorials/how-to-use-docker-exec-to-run-commands-in-a-docker-container


--------------------------------------------------------------------------------------------------------------------------

Curl command - curl means Client URL
curl is used to transfer data over the network

Now go to docker exec -it stocktracker sh

# curl https://localhost:8080/

This will see if a page the listener is working properly.

=========================================================
Kubernetes
=========================================================

1. Install kubectl [Kubernetes Client to talk to Control Plane]
	From windows powershell type -> scoop install kubectl
2. Install Kuberntes Server
	Docker > Settings > Kubernetes, Enable Kubernetes
	After this you can install Azure, AWS. Google Cloud, etc.

3. After this from powershell type the following to see if kubernetes nodes are running
   	kubectl get nodes

4. Type the following to get cluster information
	kubectl cluster-info 

5. Create a pod file and run the following command to create a pod
	kubectl apply -f pod.yml    

6. To see if it's up and running
	kubectl get pods   
 	kubectl get pods -o wide [for more information]
	kubectl describe pods stocktracker-pod [for debugging details]
7. To delete
	kubectl delete --all deployments
	Deletes all deplyments

OR  	Individual pod deployments:
	kubectl delete -f pod.yml 
OR
	kubectl delete pod <podname>

EXPOSE IMPERATIVELY

8.1 To expose a service to the web use
	Use kubectl get pods to get the name of the pod, then execute
	kubectl expose pod stocktracker-pod --type=LoadBalancer --name=stocktracker-web-svc
9.1 To see if it's running type
	kubectl get svc
10.1 To delete a service use
	kubectl delete svc stocktracker-web-svc

EXPOSE DECLARITIVELY

8.2 kubectl get pods --show-labels

9.2
    Use the label to create the service.yml
10.2 Now run
     kubectl apply -f service.yml

11. To check if they are running correctly use

kubectl get svc stocktracker-svc
OR
kubectl describe svc stocktracker-svc

