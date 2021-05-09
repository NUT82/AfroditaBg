namespace AfroditaBg.Web.ViewModels.Administration.Blog
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class BlogInputViewModel
    {
        [Required]
        public string BulgarianTitle { get; set; }

        [Required]
        public string BulgarianDescription { get; set; }

        [Required]
        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<string> Categories { get; set; }

        [Required]
        public string SelectCategory { get; set; }

        [MinLength(3)]
        public string NewCategory { get; set; }
    }
}
