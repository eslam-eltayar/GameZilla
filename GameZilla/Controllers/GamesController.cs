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
        private readonly IGameRepository _gameRepo;

        public GamesController(ApplicationDbContext context,
            IUnitOfWork unitOfWork, IGameRepository gameRepo)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _gameRepo = gameRepo;
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

            await _gameRepo.Create(model);

            return RedirectToAction(nameof(Index));
        }
    }
}
