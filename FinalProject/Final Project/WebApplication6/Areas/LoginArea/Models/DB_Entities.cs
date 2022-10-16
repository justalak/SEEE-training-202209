using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Models;

namespace WebApplication6.Models
{
    public class DB_Entities : DbContext
    {
        public DbSet<User> Users { get; set; }    
    }
}