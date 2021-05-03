namespace AfroditaBg.Web.ViewModels.Administration.Links
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class LinkInputViewModel
    {
        [Required]
        [MinLength(5)]
        public string BulgarianTitle { get; set; }

        [Required]
        [MinLength(5)]
        public string EnglishTitle { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        [Required]
        [MinLength(30)]
        public string BulgarianDescription { get; set; }

        [Required]
        [MinLength(30)]
        public string EnglishDescription { get; set; }

        public IFormFile Image { get; set; }
    }
}
