using System;
using System.Collections.Generic;

namespace CoolForum.Models
{
    public class UserBaseModel
    {
        public string UserName { get; set; }
    }

    public class User : UserBaseModel
    {
        public int Id { get; set; }
        public string SessionKey { get; set; }
        public string AuthCode { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }

    public class UserMembershipModel : UserBaseModel
    {
        public string AuthCode { get; set; }
    }

    public class UserLoggedModel : UserBaseModel
    {
        public string SessionKey { get; set; }
    }
}
