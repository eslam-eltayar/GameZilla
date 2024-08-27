using GameZilla.DataAccess.Data;
using GameZilla.Entities.Repositories;
using Microsoft.AspNetCore.Hosting;

namespace GameZilla.DataAccess.Repositories.Imp
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UnitOfWork(ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

            Category = new CategoryRepository(context);
            Device = new DeviceRepository(context);
            Game = new GameRepository(context, webHostEnvironment);
        }
        public ICategoryRepository Category { get; private set; }

        public IDeviceRepository Device { get; private set; }
        public IGameRepository Game { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
