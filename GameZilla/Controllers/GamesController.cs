using GameZilla.DataAccess.Data;
using GameZilla.Entities.Repositories;
using GameZilla.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZilla.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public GamesController(ApplicationDbContext context,
            IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var games = _unitOfWork.Game.GetAll();
            return View(games);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateFormGameViewModel viewModel = new()
            {
                CategoryList = _unitOfWork.Category.GetSelectList(),
                DeviceList = _unitOfWork.Device.GetSelectList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFormGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.DeviceList = _unitOfWork.Device.GetSelectList();
                model.CategoryList = _unitOfWork.Category.GetSelectList();

                return View(model);
            }

            await _unitOfWork.Game.Create(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
