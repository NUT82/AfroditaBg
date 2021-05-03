namespace AfroditaBg.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AfroditaBg.Data.Common.Models;

    public class Procedure : BaseDeletableModel<int>
    {
        [Required]
        public string BulgarianName { get; set; }

        [Required]
        public string EnglishName { get; set; }

        [Required]
        public string BulgarianDescription { get; set; }

        [Required]
        public string EnglishDescription { get; set; }

        public string ThumbnailImageId { get; set; }

        public Image ThumbnailImage { get; set; }

        public string ImageId { get; set; }

        public Image Image { get; set; }
    }
}
