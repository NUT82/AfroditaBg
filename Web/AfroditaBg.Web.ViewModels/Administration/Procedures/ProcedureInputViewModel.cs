namespace AfroditaBg.Web.ViewModels.Administration.Procedures
{
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;

    public class ProcedureInputViewModel
    {
        [Required]
        [MinLength(5)]
        public string BulgarianName { get; set; }

        [Required]
        [MinLength(5)]
        public string EnglishName { get; set; }

        [Required]
        [MinLength(30)]
        public string BulgarianDescription { get; set; }

        [Required]
        [MinLength(30)]
        public string EnglishDescription { get; set; }

        public IFormFile Image { get; set; }

        public IFormFile ThumbnailImage { get; set; }
    }
}
