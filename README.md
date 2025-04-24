# BookApi
Example GraphQL API using C# and Hot Chocolate

# To start an API

* If you do not have it installed, first install the .NET SDK (this code example uses .NET 9.0) from Microsoft
* On a Mac, you will need to establish a link from the SDK install location.  Assuming your install is at /usr/local/share/dotnet/x64/dotnet:
```
ln -s /usr/local/share/dotnet/x64/dotnet /usr/local/bin/
```
* If done correctly, you should now have the `dotnet` command available in your terminal.
* Run `npm run bookapi:run` or `npm run libraryapi:run` at the root of the repository.

# To update the schema.graphql file after a change

* Run `npm run bookapi:schema` or `npm run libraryapi:schema`

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
* Run `npm run router:start`
* This should then start up the Apollo router based on the `router-config-dev.yaml` file, which will start it at http://localhost:4000
* Going to this URL should bring up the Apollo Studio UI, and will let you browse and run queries against all of the APIs at once.

# To start as a container

* Ensure that you have Docker installed and running.
* Run `npm run start`
* This will start both APIs and will run the router (this is not yet containerized).
* To stop, kill the router process, then run `npm run stop` to clean up the containers.
* WARNING: Currently, the mutation call fails when running in a container due to it trying to write to a file in the container.

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
