using HotChocolate.ApolloFederation.Types;

namespace BookApi.Types;

public class Author(string id, string name)
{
    [ID]
    [Key]
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
};
