using GameZilla.Entities.Attributes;
using GameZilla.Entities.Settings;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameZilla.Entities.ViewModels
{
    public class EditFormGameViewModel : GameFormViewModel
    {
        public int Id { get; set; }
        public string? CurrentCover { get; set; }

        [AllowedExtentions(FileSettings.AllowedExtensions),
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
