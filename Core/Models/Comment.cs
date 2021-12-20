using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    //This is Feedback teble in dbdesigner
    public class Comment
    {
        [Key]
        public long Id { get; set; }
        public Hotel Hotel { get; set; }
        public User User { get; set; }
        public string CommentText { get; set; }
        [Range(1, 5)]
        public Byte Mark { get; set; } //From 1 to 5
    }
}
