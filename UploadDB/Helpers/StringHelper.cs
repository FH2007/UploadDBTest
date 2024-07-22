using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadDB.Models;

namespace UploadDB.Helpers
{
    internal class StringHelper
    {
        internal static IEnumerable<WordClass> SplitWords(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Некорректный путь файла");

            var words = new List<string>();

            using (StreamReader reader = new(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.AddRange(line.Split(' '));
                }
            }
            return words.GroupBy(word=>word).Select(x=> new WordClass(x.Key, x.Count()));

        }
    }
}
