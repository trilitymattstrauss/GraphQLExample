using BookApi.Inputs;
using Newtonsoft.Json;

namespace BookApi.Types;

[QueryType]
public static class Query
{
    public static List<Book> GetBooks(BooksQueryInput? input)
    {
        var data = File.ReadAllText("Data/Books.json");
        var books = JsonConvert.DeserializeObject<List<Book>>(data) ?? [];

        if (input != null)
        {
            return books.FindAll(a =>
            {
                if (input.Id != null && a.Id == input.Id)
                    return true;
                if (input.Title != null && a.Title == input.Title)
                    return true;
                if (input.LibraryId != null && a.LibraryId == input.LibraryId)
                    return true;
                return input.AuthorId != null && a.AuthorId == input.AuthorId;
            });
        }

        return books;
    }

    public static List<Author> GetAuthors()
    {
        var data = File.ReadAllText("Data/Authors.json");

        return JsonConvert.DeserializeObject<List<Author>>(data) ?? [];
    }

    public static Book? GetBook(BookQueryInput input)
    {
        var data = File.ReadAllText("Data/Books.json");
        var books = JsonConvert.DeserializeObject<List<Book>>(data) ?? [];

        return books.Find(a =>
        {
            if (input.Id != null && a.Id == input.Id)
                return true;
            return input.Title != null && a.Title == input.Title;
        });
    }
}
