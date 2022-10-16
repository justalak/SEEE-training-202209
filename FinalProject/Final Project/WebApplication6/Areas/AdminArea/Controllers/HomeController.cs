using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Infrastructure;
using WebApplication6.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WebApplication6.Areas.AdminArea.Controllers
{
    public class HomeController : Controller
    {
        [Area("AdminArea")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
