# Signal R - POC

Server-side code configuring a Connection Hub

## Set Up

 1. Create an azure portal account and a signal r service resource following these instructions:  https://docs.microsoft.com/en-us/azure/azure-signalr/signalr-quickstart-dotnet-core#create-an-azure-signalr-resource  
 2. Take note of your key connection string. It should have the following format:  
 		Endpoint=<service_endpoint>;AccessKey=<access_key>;  
 3. Configure dotnet user-secrets and add the connection string:  
		3.1. `dotnet user-secrets init `  
		3.2. `dotnet user-secrets set Azure:SignalR:ConnectionString "<Your connection string>"`  
4. Ruin and build:  
		4.1. `dotnet build`  
		4.2. `dotnet run`  
