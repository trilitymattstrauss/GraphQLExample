using HotChocolate.ApolloFederation.Resolvers;
using HotChocolate.ApolloFederation.Types;
using Newtonsoft.Json;

namespace BookApi.Types;

public class Book(string id, string title, string authorId, string libraryId)
{
    [ID]
    [Key]
    public string Id { get; set; } = id;
    public string Title { get; set; } = title;
    [GraphQLIgnore] public string AuthorId { get; set; } = authorId;
    [GraphQLIgnore] public string LibraryId { get; set; } = libraryId;
    
    public Library GetLibrary() => new Library { Id = LibraryId };    

    [ReferenceResolver]
    public static Book? ResolveReference(string id)
    {
        var data = File.ReadAllText("Data/Books.json");

        var books = JsonConvert.DeserializeObject<List<Book>>(data) ?? [];
        return books.Find(a => a.Id == id) ?? null;
    }
    
    public override string ToString() => "Id: " + Id + ", Title: " + Title + ", AuthorId: " + AuthorId + ", LibraryId: " + LibraryId;
}
