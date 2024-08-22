using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GameZilla.Entities.ViewModels
{
    public class CreateFormGameViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; } // FK
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        public List<int> SelectedDevices { get; set; } = new List<int>();

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();


        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        public IFormFile Cover { get; set; } = default!;

    }
}
