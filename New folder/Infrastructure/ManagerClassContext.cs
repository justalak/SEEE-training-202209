using Microsoft.EntityFrameworkCore;
using MySchool.Models;

namespace MySchool.Infrastructure
{
    public class ManagerClassContext : DbContext
    {
        public ManagerClassContext(DbContextOptions<ManagerClassContext> options) : base(options)
        {
        }
        public DbSet<Class> Classes { get; set; }
    }
}