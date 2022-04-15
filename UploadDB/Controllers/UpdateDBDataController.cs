using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadDB.DB;
using UploadDB.Models;

namespace UploadDB.Controllers
{
    internal class UpdateDBDataController
    {
        public void UpdateData(string path)
        {
            ReadTXTController read = new ReadTXTController();
            List<Word> txtData = read.Read(path);
            SetNewData(txtData);
            Console.WriteLine("Закончено");
        }
        private void SetNewData(List<Word> txtData)
        {
            if (txtData != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    foreach (var item in txtData)
                    {
                        try
                        {
                            string sql =
                            $"IF EXISTS (SELECT Id FROM Words WHERE Word= N'{item._word}') " +
                                "BEGIN " +
                                    $"UPDATE Words SET Count = Count + {item.Count} WHERE Word = N'{item._word}' " +
                                $"END " +
                            $"ELSE " +
                                $"BEGIN " +
                                    $"INSERT INTO Words(Word, Count) VALUES( N'{item._word}', {item.Count}) " +
                                $"END";
                            db.Database.ExecuteSqlRaw(sql);
                        }
                        catch
                        {
                            string sql = $"UPDATE Words SET Count = Count + {item.Count} WHERE Word = N'{item._word}'";
                            db.Database.ExecuteSqlRaw(sql);
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Недостаточно данных для обновлений");
            }
        }
    }
}
