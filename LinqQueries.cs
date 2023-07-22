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

    public bool allBooksHasStatus(){
        return this.bookCollection.All(b => b.Status != null);
    }

    public bool anyBooksWasPublishedIn2005(){
        return this.bookCollection.Any(b => b.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> GetBooksPython(){
        return this.bookCollection.Where(b => b.Categories.Contains("Python"));
    }

    public IEnumerable<Book> GetJavaBooksOrderedByName(){
        return this.bookCollection.Where(b => b.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> GetBooksWithMoreThan250PagesOrdered(){
        return this.bookCollection.Where(b => b.PageCount > 450).OrderByDescending(p => p.PageCount);
    }
}