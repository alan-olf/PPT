using Microsoft.AspNetCore.Mvc;

namespace PPT.App.WebApi.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
