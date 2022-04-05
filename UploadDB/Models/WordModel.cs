using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadDB.Models
{
    public class WordModel
    {
        public int? Id { get; set; }

        //[Column(TypeName = "varchar(20)")]        
        public string Word { get; set; }
        public int Count { get; set; }
    }
}
