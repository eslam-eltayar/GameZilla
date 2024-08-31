using GameZilla.DataAccess.Data;
using GameZilla.Entities.Models;
using GameZilla.Entities.Repositories;
using GameZilla.Entities.Settings;
using GameZilla.Entities.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZilla.DataAccess.Repositories.Imp
{
    public class GameRepository : GenericRepository<Game>, IGameRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _imagePath;

        public GameRepository(ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
            : base(context)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _imagePath = $"{_webHostEnvironment.WebRootPath}{FileSettings.ImagesPath}";
        }

        public async Task Create(CreateFormGameViewModel model)
        {
            var coverName = await SaveCover(model.Cover);

            Game game = new()
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Cover = coverName,
                GameDevices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList()
            };

            _context.Add(game);
            _context.SaveChanges();
        }

        
        public async Task<Game?> Update(EditFormGameViewModel model)
        {
            var game = _context.Games
            .Include(g => g.GameDevices)
            .SingleOrDefault(g => g.Id == model.Id);

            if (game is null)
                return null;

            var oldCover = game.Cover;

            game.Name = model.Name;
            game.Description = model.Description;
            game.CategoryId = model.CategoryId;
            game.GameDevices = model.SelectedDevices.Select(d => new GameDevice { DeviceId = d }).ToList();

            if (model.Cover is not null)
            {
                game.Cover = await SaveCover(model.Cover!);
            }

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                if (model.Cover is not null)
                {
                    var cover = Path.Combine(_imagePath, oldCover);
                    File.Delete(cover);
                }

                return game;
            }
            else
            {
                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(cover);

                return null;
            }
        }

        public bool Delete(int id)
        {
            var isDeleted = false;

            var game = _context.Games.Find(id);

            if (game is null)
                return isDeleted;

            _context.Remove(game);

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;

                var cover = Path.Combine(_imagePath, game.Cover);
                File.Delete(cover);
            }

            return isDeleted;

        }

        private async Task<string> SaveCover(IFormFile cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";

            var path = Path.Combine(_imagePath, coverName);

            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);

            return coverName;
        }
    }
}
