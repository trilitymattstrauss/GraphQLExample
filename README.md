# BookApi
Example GraphQL API using C# and Hot Chocolate

# To start an API

* If you do not have it installed, first install the .NET SDK (this code example uses .NET 9.0) from Microsoft
* On a Mac, you will need to establish a link from the SDK install location.  Assuming your install is at /usr/local/share/dotnet/x64/dotnet:
```
ln -s /usr/local/share/dotnet/x64/dotnet /usr/local/bin/
```
* If done correctly, you should now have the `dotnet` command available in your terminal.
* To run the API, go to the root of the API project and run the following command:
```
dotnet run --no-hot-reload
```
* Once completed, you should now be able to go to http://localhost:4001/graphql which will bring up a GraphQL explorer to view the API.  Replace `4001` with the configured port of the API being run.

# To update the schema.graphql file after a change

When in one of the API projects, run the following command at the root level of the project:
```
dotnet run -- schema export --output schema.graphql
```

# To start the Apollo Supergraph locally

* If you do not have it installed already, you will need to install the `rover CLI`.  Follow the instructions here to install this: https://www.apollographql.com/docs/rover/getting-started
* You should be able to run commands in the terminal for `rover` assuming this was installed correctly.
* This repository contains a couple of files for an example of Apollo federation (`router-config-dev.yaml` and `supergraph-config-dev.yaml`)
* Ensure that the `schema.graphql` files are up to date in both APIs.
* In `supergraph-config-dev.yaml`, you should see (one example of an API, there may be multiple in the file)
```
  book:
    routing_url: http://localhost:4001/graphql
    schema:
      file: ./BookApi/schema.graphql
```
* Ensure that the `routing_url` is the same as the URL to access the specific API.
* Ensure that the path to the `schema.graphql` file is correct (relative to the yaml file)
* First, start up the APIs listed in `supergraph-config-dev.yaml`.
* Next, run the below command to start the supergraph router (you should be in the directory with the yaml files when running this command):
```
rover dev \
--supergraph-config supergraph-config-dev.yaml \
--router-config router-config-dev.yaml
```
* This should then start up the Apollo router based on the `router-config-dev.yaml` file, which will start it at http://localhost:4000
* Going to this URL should bring up the Apollo Studio UI, and will let you browse and run queries against all of the APIs at once.

# Querying the Graph

* On either the specific API UI or the federated graph UI, open up a query document.
* Some example queries that you can run:
```
-- Query hitting a specific API only (can be run from an API specific URL):
query ExampleQuery {
  books {
    author {
      name
    }
    title
  }
}

-- Example mutation call (will need a JSON object for book provided in the request):
mutation AddBook($book: BookInput!) {
    addBook(book: $book) {
        id
    }
}

-- Query that utilizes Apollo Federation (must be executed from the Apollo UI (port 4000)
query ExampleQuery {
  books {
    author {
      name
    }
    library {
      name
    }
    title
  }
}
```
