using System.Security.Cryptography.X509Certificates;

public class LinqQueries
{
    private List<Book> bookCollection = new List<Book>();

    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.bookCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

    }
    public IEnumerable<Book> GetBooks()
    {
        return this.bookCollection;
    }
}