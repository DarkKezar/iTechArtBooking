﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    //This is Feedback teble in dbdesigner
    public class Comment
    {
        public long Id { get; set; }
        public Hotel HotelId { get; set; }
        public User UserId { get; set; }
        public string CommentText { get; set; }
        public SByte Mark { get; set; } //From 1 to 5
    }
}
