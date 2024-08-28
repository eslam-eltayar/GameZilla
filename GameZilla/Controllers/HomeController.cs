using GameZilla.Entities.Models;
using GameZilla.Entities.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameZilla.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var games = _unitOfWork.Game.GetAll(Includes: "GameDevices.Device,Category");
            return View(games);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
