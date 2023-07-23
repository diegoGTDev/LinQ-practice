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
// printValues(queries.ThirthAndFourthBookWithMoreThan400Pages());
Console.Write(queries.getMinimalDate());
Console.WriteLine(queries.getMaxDate());
Console.WriteLine(queries.TheMinimalPageCountDiffToZero().Title);
// printItemValues(queries.TitleAndPageCountOfTheFirstThirthElements());
// Suma
// Console.WriteLine($"La suma es de: {queries.SumAllThePagesOfBooksBetween200and500()}");
// Console.WriteLine(queries.TitlesAbove2015());
// printGroup(queries.group());
void printValues(IEnumerable<Book> data){
    Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Title", "PageCount", "PublishedDate");
    foreach(var item in data){
        Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}

// void printItemValues(IEnumerable<Item> data){
//     Console.WriteLine("{0, -60} {1,15}\n", "Title", "Pages");
//     foreach(var i in data){
//         Console.WriteLine("{0, -60} {1,15}", i.Title, i.Pages);
//     }
// }

void printGroup(IEnumerable<IGrouping<int,Book>> data){
    foreach(var grupo in data){
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1,15} {2,15}\n", "Title", "PageCount", "PublishedDate");
        foreach(var item in grupo){
            Console.WriteLine("{0,-60} {1,15} {2,15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }

}