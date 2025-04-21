# BookApi
Example GraphQL API using C# and Hot Chocolate

# To start the API

* If you do not have it installed, first install the .NET SDK (this code example uses .NET 9.0) from Microsoft
* On a Mac, you will need to establish a link from the SDK install location.  Assuming your install is at /usr/local/share/dotnet/x64/dotnet:
```
ln -s /usr/local/share/dotnet/x64/dotnet /usr/local/bin/
```
* If done correctly, you should now have the `dotnet` command available in your terminal.
* To run the API, go to the root of the project and run the following command:
```
dotnet run --no-hot-reload
```
* Once completed, you should now be able to go to `http://localhost:4001/graphql` which will bring up a GraphQL explorer to view the API.

# To update the schema.graphql file after a change

* In order to make changes to the API available to the federated graph, you will need to make sure that the `schema.graphql` file contains the latest schema definition.
* To do so, start the API using the steps above.
* In the explorer, open a new or existing document, then click on the `Schema` tab.
* Copy the contents from this tab to the `schema.graphql` file in the project.

# To start the Apollo Supergraph locally

* This repository contains a couple of files for an example of Apollo federation (`router-config-dev.yaml` and `supergraph-config-dev.yaml`)
* Ensure that the `schema.graphql` files are up to date in both APIs.
* In `supergraph-config-dev.yaml`, you should see 
* First, start up this API, as well as the LibraryApi (different repository) on your local machine.
* This should have one API deployed to port 4001, and the other to 4002.