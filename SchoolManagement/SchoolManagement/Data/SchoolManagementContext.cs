using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Data
{
    public class SchoolManagementContext : DbContext
    {
        public SchoolManagementContext (DbContextOptions<SchoolManagementContext> options) : base(options)
        {

        }
        public DbSet<StudentInfo> studentInfos { get; set; }
        public DbSet<ClassInfo> classInfos { get; set; }
        public DbSet<TeacherInfo> teacherInfos { get; set; }
    }
}
