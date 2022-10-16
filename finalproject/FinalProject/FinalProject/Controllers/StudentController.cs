using Microsoft.AspNetCore.Mvc;
using FinalProject.Model.Menu;
using FinalProject.Model;

namespace FinalProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet(Name = "GetStudent")]
        public List<Student> GetStudent()
        {
            StudentMenu studentMenu = new StudentMenu();
            return studentMenu.Show();
        }
    }
}
