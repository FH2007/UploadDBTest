using UploadDB.Models;
using UploadDB.Helpers;
using UploadDB;

var path = "F:\\repos\\UploadDBTest\\UploadDB\\txt\\1.txt";

try
{
    Document document = new(path);
    using ApplicationContext db = new();
    foreach (var word in document.Words)
    {
        UpdateDB.AddWord(word, db);
    }
    Console.WriteLine("Готово");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
Console.ReadKey();


