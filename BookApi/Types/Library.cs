using HotChocolate.ApolloFederation.Types;

namespace BookApi.Types;

public class Library
{
    [ID]
    [Key]
    public string Id { get; set; }
}