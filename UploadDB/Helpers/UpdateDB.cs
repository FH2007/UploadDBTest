using Microsoft.EntityFrameworkCore;
using UploadDB.Models;

namespace UploadDB.Helpers
{
    internal class UpdateDB
    {
        internal static void AddWord(WordClass word, ApplicationContext db)
        {
            db.Database.ExecuteSqlRaw($"InsertWords @word= {word.Word}, @Count = {word.Count}");            
        }
    }
}
