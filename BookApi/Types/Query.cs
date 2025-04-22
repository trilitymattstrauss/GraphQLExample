using Newtonsoft.Json;

namespace BookApi.Types;

[QueryType]
public static class Query
{
    public static List<Book> GetBooks()
    {
        var data = File.ReadAllText("Data/Books.json");

        return JsonConvert.DeserializeObject<List<Book>>(data) ?? [];
    }

    public static List<Author> GetAuthors()
    {
        var data = File.ReadAllText("Data/Authors.json");

        return JsonConvert.DeserializeObject<List<Author>>(data) ?? [];
    }

    public static Book? GetBook(string id)
    {
        var data = File.ReadAllText("Data/Books.json");
        var books = JsonConvert.DeserializeObject<List<Book>>(data) ?? [];

        return books.Find(a => a.Id == id);
    }
}
