using BookApi.Types;
using Newtonsoft.Json;

namespace BookApi.Extensions;

[ExtendObjectType<Book>]
public class BookExtensions
{
    [BindMember(nameof(Book.AuthorId))]
    public Author? GetAuthor([Parent] Book book)
    {
        var data = File.ReadAllText("Data/Authors.json");

        var authors = JsonConvert.DeserializeObject<List<Author>>(data) ?? [];
        return authors.FirstOrDefault(a => a.Id == book.AuthorId);
    }
}