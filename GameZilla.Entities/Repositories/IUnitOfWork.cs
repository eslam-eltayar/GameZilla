﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZilla.Entities.Repositories
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IDeviceRepository Device { get; }
        IGameRepository Game { get; }
        int Complete();
    }
}
