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
    
    public interface IWordModel
    {
        static int Count;
        static string Word;
    }
    public class Word : IWordModel
    {
        public int Count { get; private set; }
        public string _word { get; private set; }
        public Word(string Word)
        {
            if ((Word != null) && (Word.Length >= 3) && (Word.Length <= 20) && (Word != "") && (Word != " "))
            {
                this._word = Word;
                this.Count = 1;
            }
        }
        public Word(string Word, int Count)
        {
            if ((Word != null) && (Word.Length >= 3) && (Word.Length <= 20) && (Word != "") && (Word != " ") && (Count != 0))
            {
                this._word = Word;
                this.Count = Count;
            }
        }
        public void AddCount()
        {
            this.Count++;
        }
    }
    
    public class WordDB : IWordModel
    {        
        public int Id { get; set; }
        public int Count { get; set; }
        public string Word { get; set; }
    }
}
