using System.Security.Cryptography.X509Certificates;

public class LinqQueries
{
    private List<Book> bookCollection = new List<Book>();

    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.bookCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        }

    }
    public IEnumerable<Book> GetBooks()
    {
        return this.bookCollection;
    }

    public IEnumerable<Book> GetBooksAfter2000()
    {
        //Extension method
        // return this.bookCollection.Where(b => b.PublishedDate.Year > 2000);
        //Querie Expression method
        return from l in this.bookCollection
               where l.PublishedDate.Year > 2000
               select l;
    }
}