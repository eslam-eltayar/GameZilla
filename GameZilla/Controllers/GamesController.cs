using Microsoft.AspNetCore.Mvc;

namespace GameZilla.Controllers
{
    public class GamesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
