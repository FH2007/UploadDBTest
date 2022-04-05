using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadDB.DB;
using UploadDB.Models;

namespace UploadDB.Controllers
{
    internal class GetDataFromDBController
    {
        public List<WordModel> GetData(List<string> words)
        {
            List<WordModel> data = new List<WordModel>();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach(var word in words)
                {
                    var Word = db.Words.Where(x=>x.Word == word).FirstOrDefault();
                    if (Word != null)
                    data.Add(Word);
                }

                Console.WriteLine("Список объектов:");
                foreach (WordModel u in data)
                {
                    Console.WriteLine($"{u.Id}.{u.Word} - {u.Count}");
                }
            }
            return data;
        }
    }
}
