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
            var games = _unitOfWork.Game.GetAll(Includes: "GameDevices.Device,Category");
            return View(games);
        }

        public IActionResult Details(int id)
        {
            var game = _unitOfWork.Game.GetById(x=>x.Id == id , Includes: "GameDevices.Device,Category");
            if(game is null)
            {
                return NotFound();
            }

            return View(game);
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

        public IActionResult Edit(int id)
        {
            var game = _unitOfWork.Game.GetById(x => x.Id == id);
            if (game is null)
            {
                return NotFound();
            }

            EditFormGameViewModel viewModel = new()
            {
                Id = id,
                Name = game.Name,
                Description = game.Description,
                CategoryId = game.CategoryId,
                SelectedDevices = game.GameDevices.Select(d=>d.DeviceId).ToList(),
                CategoryList = _unitOfWork.Category.GetSelectList(),
                DeviceList = _unitOfWork.Device.GetSelectList(),
                CurrentCover = game.Cover

            };

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditFormGameViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.DeviceList = _unitOfWork.Device.GetSelectList();
                model.CategoryList = _unitOfWork.Category.GetSelectList();

                return View(model);
            }

            await _unitOfWork.Game.Update(model);

            return RedirectToAction(nameof(Index));
        }

    }
}
