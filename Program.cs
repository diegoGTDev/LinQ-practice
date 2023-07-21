LinqQueries queries = new LinqQueries();
//All the books
// printValues(queries.GetBooks());
//Get books after 2000
printValues(queries.GetBooksAfter2000());
void printValues(IEnumerable<Book> data){
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Title", "PageCount", "PublishedDate");
    foreach(var item in data){
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}