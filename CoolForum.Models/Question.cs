using System;
using System.Collections.Generic;

namespace CoolForum.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }

    public class QuestionModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
