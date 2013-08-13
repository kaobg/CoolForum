using System;

namespace CoolForum.Models
{
    public class UserBaseModel
    {
        public string UserName { get; set; }
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