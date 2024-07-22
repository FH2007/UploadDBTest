using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadDB.Models
{
    public class WordClass
    {
        public WordClass(string word, int count)
        {
            Word = word;
            Count = count;
        }
        public int Count { get; private set; }
        public string Word { get; private set; }
        private bool IsRequiredLength
        {
            get
            {
                return Word.Length >= 3 && Word.Length <= 20;
            }
        }
        public bool IsMatch => IsRequiredLength && Count >= 4;
    }
}
