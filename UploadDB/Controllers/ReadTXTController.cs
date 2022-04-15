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
        public List<Word> Read(string path)
        {
            List<Word> list = new List<Word>();
            if (path != null)
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] subs = line.Split(' ');
                        foreach (string s in subs)
                        {
                            if (list.Select(x => x._word).Contains(s))
                            {
                                list.Single(x => x._word == s).AddCount();
                            }
                            else
                                list.Add(new Word(s));
                        }
                    }
                }
                return list.Where(x => x.Count >= 4).ToList();
            }
            throw new Exception("Некорректный путь файла");
        }
    }
}
