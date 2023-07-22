LinqQueries queries = new LinqQueries();
//All the books
// printValues(queries.GetBooks());
//Get books after 2000
// printValues(queries.GetBooksAfter2000());
//All books has status
// Console.WriteLine(queries.allBooksHasStatus());
//Any books was published in 2005
// Console.WriteLine(queries.anyBooksWasPublishedIn2005());
//Get Books with categorie python
// printValues(queries.GetBooksPython());
// printValues(queries.GetJavaBooksOrderedByName());
// printValues(queries.GetBooksWithMoreThan250PagesOrdered());
// printValues(queries.GetTheFirstThreeBooksJavaOrederedByDate());
printValues(queries.ThirthAndFourthBookWithMoreThan400Pages());
void printValues(IEnumerable<Book> data){
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Title", "PageCount", "PublishedDate");
    foreach(var item in data){
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}