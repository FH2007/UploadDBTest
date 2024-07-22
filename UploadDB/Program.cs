// See https://aka.ms/new-console-template for more information
using UploadDB.Models;
using UploadDB.Helpers;


var path = "D:/Work/TestTasks/repos/UploadDBTest/UploadDB/txt/1.txt";

try
{
    IEnumerable<WordClass> words = StringHelper.SplitWords(path).Where(x => x.IsMatch);
    UpdateDB.AddWords(words);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}


Console.ReadKey();


