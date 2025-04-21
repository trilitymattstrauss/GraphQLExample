namespace LibraryApi.Types;

[QueryType]
public static class Query
{
    public static Library GetLibrary()
        => new Library("Super cool Library");
}
