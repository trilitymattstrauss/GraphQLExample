using HotChocolate.ApolloFederation.Types;

namespace LibraryApi.Types;

public class Book
{
    [ID]
    [Key]
    public string Id { get; set; }
}