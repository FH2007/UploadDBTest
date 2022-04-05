// See https://aka.ms/new-console-template for more information
using UploadDB.Controllers;
using UploadDB.Models;
using System.Threading;
using UploadDB.DB;

Console.WriteLine("Hello");
Thread myThread1 = new Thread(() =>
{
    UpdateDBDataController updateDB = new UpdateDBDataController();
    updateDB.UpdateData("D:/Work/TestTasks/repos/UploadDBTest/UploadDB/txt/1.txt");
});
Thread myThread2 = new Thread(() =>
{
    UpdateDBDataController updateDB = new UpdateDBDataController();
    updateDB.UpdateData("D:/Work/TestTasks/repos/UploadDBTest/UploadDB/txt/2.txt");
});
myThread1.Start();
myThread2.Start();
using (ApplicationContext db = new ApplicationContext())
{
    List<WordModel> words = db.Words.ToList();
    foreach (WordModel word in words)
    {
        Console.WriteLine($"{word.Word} - {word.Count}");
    }

}


