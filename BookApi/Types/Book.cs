namespace BookApi.Types;

public class Book(string id, string title, string authorId)
{
    public string Id { get; set; } = id;
    public string Title { get; set; } = title;
    [GraphQLIgnore]
    public string AuthorId { get; set; } = authorId;
}
