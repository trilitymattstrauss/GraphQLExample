using HotChocolate.ApolloFederation.Resolvers;
using HotChocolate.ApolloFederation.Types;
using Newtonsoft.Json;

namespace LibraryApi.Types;

public class Library(string id, string name)
{
    [ID]
    [Key]
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;

    [ReferenceResolver]
    public static Library? ResolveReference(string id)
    {
        var data = File.ReadAllText("Data/Libraries.json");

        var books = JsonConvert.DeserializeObject<List<Library>>(data) ?? [];
        return books.Find(a => a.Id == id) ?? null;
    }
}
