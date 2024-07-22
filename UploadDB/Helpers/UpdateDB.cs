using Microsoft.EntityFrameworkCore;
using UploadDB.Models;

namespace UploadDB.Helpers
{
    internal class UpdateDB
    {
        internal static void AddWords(IEnumerable<WordClass> list)
        {
            using ApplicationContext db = new();
            foreach (var element in list)
            {
                try
                {
                    string sql =
                    $"IF EXISTS (SELECT Id FROM Words WHERE Word= N'{element.Word}') " +
                        "BEGIN " +
                            $"UPDATE Words SET Count = Count + {element.Count} WHERE Word = N'{element.Word}' " +
                        $"END " +
                    $"ELSE " +
                        $"BEGIN " +
                            $"INSERT INTO Words(Word, Count) VALUES( N'{element.Word}', {element.Count}) " +
                        $"END";
                    db.Database.ExecuteSqlRaw(sql);
                }
                catch
                {
                    string sql = $"UPDATE Words SET Count = Count + {element.Count} WHERE Word = N'{element.Word}'";
                    db.Database.ExecuteSqlRaw(sql);
                }
            }            
        }
    }
}
