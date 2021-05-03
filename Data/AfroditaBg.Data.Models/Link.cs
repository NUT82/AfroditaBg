namespace AfroditaBg.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AfroditaBg.Data.Common.Models;

    public class Link : BaseDeletableModel<int>
    {
        [Required]
        public string BulgarianTitle { get; set; }

        [Required]
        public string EnglishTitle { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string BulgarianDescription { get; set; }

        [Required]
        public string EnglishDescription { get; set; }

        [Required]
        public string ImageId { get; set; }

        public Image Image { get; set; }
    }
}
