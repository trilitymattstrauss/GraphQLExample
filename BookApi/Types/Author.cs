using Newtonsoft.Json;

namespace BookApi.Types;

public class Author(string id, string name)
{
    public string Id { get; set; } = id;
    public string Name { get; set; } = name;
};
