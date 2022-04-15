// See https://aka.ms/new-console-template for more information
using UploadDB.Controllers;
using UploadDB.Models;
using UploadDB.DB;

Console.WriteLine("Hello");
UpdateDBDataController updateDB = new UpdateDBDataController();
updateDB.UpdateData("D:/Work/TestTasks/repos/UploadDBTest/UploadDB/txt/1.txt");

using (ApplicationContext db = new ApplicationContext())
{
    List<Word> words = db.Words.Select(a=> new Word(a.Word,a.Count)).ToList();
    foreach (Word word in words)
    {
        Console.WriteLine($"{word._word} - {word.Count}");
    }
}
Console.ReadKey();


