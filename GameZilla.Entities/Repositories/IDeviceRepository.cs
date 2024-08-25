﻿using GameZilla.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GameZilla.Entities.Repositories
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
