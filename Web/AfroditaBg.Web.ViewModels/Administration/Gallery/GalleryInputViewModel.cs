namespace AfroditaBg.Web.ViewModels.Administration.Gallery
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class GalleryInputViewModel
    {
        public string BulgarianDescription { get; set; }

        public string ModelName { get; set; }

        [Required]
        public IFormFile Image { get; set; }

        public IEnumerable<string> Tags { get; set; }

        [Required]
        public string SelectTag { get; set; }

        [MinLength(3)]
        public string NewTag { get; set; }
    }
}
