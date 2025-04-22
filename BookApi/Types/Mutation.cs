using BookApi.Inputs;
using Newtonsoft.Json;

namespace BookApi.Types;

[MutationType]
public class Mutation
{
    public Book AddBook(BookInput book)
    {
        var data = File.ReadAllText("Data/Books.json");
        var books = JsonConvert.DeserializeObject<List<Book>>(data) ?? [];
        
        var bookToAdd = new Book(book.Id, book.Title, book.AuthorId, book.LibraryId);
        books.Add(bookToAdd);
        
        File.WriteAllText("Data/Books.json", JsonConvert.SerializeObject(books, Formatting.Indented));
        
        return bookToAdd;
    }
}