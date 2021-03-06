﻿using System;

namespace CoolForum.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
