using GameZilla.Entities.Models;
using GameZilla.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZilla.Entities.Repositories
{
    public interface IGameRepository : IGenericRepository<Game>
    {
        Task Create(CreateFormGameViewModel model);
    }
}
