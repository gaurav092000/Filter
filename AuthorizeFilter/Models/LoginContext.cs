using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AuthorizeFilter.Models
{
    public class LoginContext : DbContext

    {
        public DbSet<LoginUser> logins { get; set; } 
      

    }
}