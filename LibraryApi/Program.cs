var builder = WebApplication.CreateBuilder(args);

builder
    .AddGraphQL()
    .AddApolloFederation()
    .AddTypes();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
