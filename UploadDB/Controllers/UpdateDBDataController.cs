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
        public void UpdateData()
        {
            ReadTXTController read = new ReadTXTController();
            List<WordModel> txtData = read.Read("D:/Work/TestTasks/repos/UploadDBTest/UploadDB/txt/1.txt");
            SetNewData(txtData);
        }
        private void SetNewData(List<WordModel> txtData)
        {
            if(txtData != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    foreach (var item in txtData)
                    {
                        WordModel word = db.Words.FirstOrDefault(x => x.Word == item.Word);
                        if (word != null)
                        {
                            word.Count = word.Count + item.Count;
                            db.Words.Update(word);                            
                        }
                        else
                        {
                            db.Words.Add(new WordModel { Word = item.Word, Count = item.Count });
                        }
                    }
                    db.SaveChanges();
                }
            }
            else
            {
                throw new Exception("Недостаточно данных для обновлений");
            }
        }
    }
}
