using UploadDB.Models;

namespace UploadDB.Helpers
{
    internal class StringHelper
    {
        internal static string[] GetLines(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Некорректный путь файла");
            return File.ReadAllLines(path);
        }

        internal static IEnumerable<WordClass> SplitWords(string[] lines)
        {
            if(lines is null)
                throw new ArgumentNullException("Пустой массив строк");

            var words = new List<string>();

            foreach (var line in lines)
            {
                words.AddRange(line.Split(' '));
            }

            return words.GroupBy(word=>word).Select(x=> new WordClass(x.Key, x.Count()));

        }
    }
}
