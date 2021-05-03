namespace AfroditaBg.Web.ViewModels.Administration.Gallery
{
    using System.ComponentModel.DataAnnotations;

    public class TagInputViewModel
    {
        [Required]
        [MinLength(3)]
        public string BulgarianName { get; set; }

        [Required]
        [MinLength(3)]
        public string EnglishName { get; set; }
    }
}
