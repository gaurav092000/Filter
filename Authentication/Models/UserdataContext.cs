using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Authentication.Models
{
    public class UserdataContext : DbContext
    {
        public DbSet<UserData> userDatas { get; set; }
    }
}