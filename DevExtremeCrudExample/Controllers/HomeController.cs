using DevExtremeCrudExample.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace DevExtremeCrudExample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Students()
        {
            return View();
        }
    }
}
