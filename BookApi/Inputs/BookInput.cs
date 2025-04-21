namespace BookApi.Inputs;

public class BookInput
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string AuthorId { get; set; }
    public string LibraryId { get; set; }
}