using Microsoft.EntityFrameworkCore;
using MySchool.Models;

namespace MySchool.Infrastructure
{
    public class ManagerAdminContext : DbContext
    {
        public ManagerAdminContext(DbContextOptions<ManagerAdminContext> options) : base(options) { }
        public DbSet<Admin> admins { get; set; }
    }
}
