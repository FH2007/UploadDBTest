using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadDB.Models;

namespace UploadDB.Controllers
{
    internal class ReadTXTController
    {
        public string path { get; set; }
        public List<WordModel> Read()
        {
            List<WordModel> list = new List<WordModel>();
            if(path != null)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] subs = line.Split(' ');
                        foreach (string s in subs)
                        {
                            if ((s != null) && (s.Length >= 3) && (s.Length <= 20))
                            {
                                if (list.Select(x => x.Word).Contains(s))
                                {
                                    list.Single(x => x.Word == s).Count++;

                                    //WordModel word = list.Single(x => x.Word == s);
                                    //word.Count++;
                                    //list.Add(word);
                                }
                                else
                                    list.Add(new WordModel { Word = s, Count = 1 });
                            }
                        }
                    }
                }
                return list.Where(x => x.Count >= 4).ToList();
            }
            throw new Exception("Пустой путь файла");
        }
    }
}
