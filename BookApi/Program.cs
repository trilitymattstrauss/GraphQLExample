using BookApi.Extensions;
using BookApi.Types;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddGraphQL()
    .AddApolloFederation()
    .AddTypes()
    .AddTypeExtension<BookExtensions>();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
