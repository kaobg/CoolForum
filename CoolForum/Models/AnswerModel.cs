using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolForum.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostTime { get; set; }
        public string Author { get; set; }
    }
}