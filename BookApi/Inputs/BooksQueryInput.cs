namespace BookApi.Inputs;

public class BooksQueryInput
{
    public string? Id { get; set; } = null;
    public string? Title { get; set; } = null;
    public string? AuthorId { get; set; } = null;
    public string? LibraryId { get; set; } = null;
}