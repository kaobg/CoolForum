using System;
using System.Collections.Generic;

namespace CoolForum.Models
{
    

    public class User
    {
        public User()
        {
            this.Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string SessionKey { get; set; }
        public string AuthCode { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }

    
}
