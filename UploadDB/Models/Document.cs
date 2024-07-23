using UploadDB.Helpers;

namespace UploadDB.Models
{
    internal class Document
    {
        public string Path { get; private set; }
        public Document(string path)
        {
            if(!File.Exists(path))
                throw new Exception("Некорректный путь файла");
            Path = path;
        }
        private string[] Lines => StringHelper.GetLines(Path);
        public IEnumerable<WordClass> Words => StringHelper.SplitWords(Lines).Where(x => x.IsMatch);
    }
}
