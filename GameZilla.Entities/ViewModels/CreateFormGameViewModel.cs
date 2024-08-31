using GameZilla.Entities.Attributes;
using GameZilla.Entities.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZilla.Entities.ViewModels
{
    public class CreateFormGameViewModel : GameFormViewModel
    {
     
        [AllowedExtentions(FileSettings.AllowedExtensions),
            MaxFileSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;

    }
}
