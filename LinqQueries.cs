using System.Security.Cryptography;
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
        return this.bookCollection.Where(b => b.PageCount > 250).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> GetTheFirstThreeBooksJavaOrederedByDate(){
        return this.GetJavaBooksOrderedByName()
        .OrderByDescending(p => p.PublishedDate).
        Take(3);
    }

    public IEnumerable<Book> ThirthAndFourthBookWithMoreThan400Pages(){

        // return this.bookCollection.Where(p => p.PageCount > 400)
        // .Take(4)
        // .Skip(2);
        
        //* Using TakeWhile
        return this.bookCollection
        .TakeWhile(b => b.PageCount > 400);
    }
    //Reto clase 16 Before class
    public IEnumerable<Item> TitleAndPageCountOfTheFirstThirthElements(){
        return this.bookCollection.Take(3)
        .Select(p => new Item { Title = p.Title, Pages = p.PageCount });
    }

    public DateTime getMinimalDate(){
        return this.bookCollection.Min(p => p.PublishedDate);
    }
    public DateTime getMaxDate(){
        return this.bookCollection.Max(p => p.PublishedDate);
    }

    public Book TheMinimalPageCountDiffToZero(){
        return this.bookCollection.Where(book => book.PageCount > 0).MinBy(p=>p.PublishedDate)!;
    }

    public int SumAllThePagesOfBooksBetween200and500(){
        return this.bookCollection.Where(predicate => predicate.PageCount >= 200 && predicate.PageCount <= 500 ).Sum(p => p.PageCount);
    }

    public string TitlesAbove2015(){
        return this.bookCollection
        .Where(p => p.PublishedDate.Year > 2015)
        .Aggregate("" ,(TituloLibros, next) =>
        {
            if (TituloLibros != string.Empty){
                TituloLibros += "-" + next.Title;
            }
            else{
                TituloLibros += next.Title;
            }
            return TituloLibros;
        }
        );
    }

    public IEnumerable<IGrouping<int,Book>> group(){
        return this.bookCollection.Where(p => p.PublishedDate.Year >= 2000)
        .GroupBy(p => p.PublishedDate.Year);
    }

}