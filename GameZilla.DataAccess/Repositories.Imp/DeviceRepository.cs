using GameZilla.DataAccess.Data;
using GameZilla.Entities.Models;
using GameZilla.Entities.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZilla.DataAccess.Repositories.Imp
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        private readonly ApplicationDbContext _context;

        public DeviceRepository(ApplicationDbContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
            return _context.Devices.Select
                 (d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
                 .OrderBy(d => d.Text)
                 .ToList();
        }
    }
}
