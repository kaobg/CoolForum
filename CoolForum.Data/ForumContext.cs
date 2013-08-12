using CoolForum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace CoolForum.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext()
            : base("DefaultConnection") { }

        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
