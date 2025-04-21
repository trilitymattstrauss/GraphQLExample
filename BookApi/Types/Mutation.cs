using BookApi.Inputs;

namespace BookApi.Types;

[MutationType]
public class Mutation
{
    public Book AddBook(BookInput book)
    {
        return new Book(book.Id, book.Title, book.AuthorId);
    }
}