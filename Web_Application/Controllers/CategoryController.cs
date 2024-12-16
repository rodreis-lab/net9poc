using Microsoft.AspNetCore.Mvc;

namespace Web_Application.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
