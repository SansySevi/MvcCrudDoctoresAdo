using Microsoft.AspNetCore.Mvc;

namespace MvcCrudDoctoresAdo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
