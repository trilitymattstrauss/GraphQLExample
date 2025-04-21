using Newtonsoft.Json;

namespace LibraryApi.Types;

[QueryType]
public static class Query
{
    public static List<Library> GetLibraries()
    {
        var data = File.ReadAllText("Data/Libraries.json");

        return JsonConvert.DeserializeObject<List<Library>>(data) ?? [];
    }
}
