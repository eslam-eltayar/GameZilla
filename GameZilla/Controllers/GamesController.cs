using GameZilla.DataAccess.Data;
using GameZilla.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZilla.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateFormGameViewModel viewModel = new()
            {
                CategoryList = _context.Categories.Select
                (c => new SelectListItem{ Value = c.Id.ToString(), Text = c.Name })
                .OrderBy(c=>c.Text)
                .ToList() ,
                
                DeviceList = _context.Devices.Select
                (d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                .OrderBy(d => d.Text)
                .ToList()

            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateFormGameViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
