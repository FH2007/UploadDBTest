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
            List<WordModel> txtData = read.Read(path);
            SetNewData(txtData);
            Console.WriteLine("Закончено");            
        }
        private void SetNewData(List<WordModel> txtData)
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
                            $"IF EXISTS (SELECT Id FROM Words WHERE Word= N'{item.Word}') " +
                                "BEGIN " +
                                    $"UPDATE Words SET Count = Count + {item.Count} WHERE Word = N'{item.Word}' " +
                                $"END " +
                            $"ELSE " +
                                $"BEGIN " +
                                    $"INSERT INTO Words(Word, Count) VALUES( N'{item.Word}', {item.Count}) " +
                                $"END";
                            db.Database.ExecuteSqlRaw(sql);
                        }
                        catch
                        {
                            string sql = $"UPDATE Words SET Count = Count + {item.Count} WHERE Word = N'{item.Word}'";
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


            //if (txtData != null)
            //{
            //    foreach (var item in txtData)
            //    {
            //        using (ApplicationContext db = new ApplicationContext())
            //        {
            //            WordModel word = db.Words.FirstOrDefault(x => x.Word == item.Word);
            //            if (word != null)
            //            {
            //                word.Count = word.Count + item.Count;
            //                db.Words.Update(new WordModel { Word = word.Word, Count = db.Words.FirstOrDefault(x => x.Word == item.Word).Count + item.Count });
            //                //db.Words.Update(word);
            //            }
            //            else
            //            {
            //                db.Words.Add(new WordModel { Word = item.Word, Count = item.Count });
            //            }
            //            db.SaveChanges();
            //        }
            //    }

            //}
            //else
            //{
            //    throw new Exception("Недостаточно данных для обновлений");
            //}
            //}
        }
}
