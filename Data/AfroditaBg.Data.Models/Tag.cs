namespace AfroditaBg.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AfroditaBg.Data.Common.Models;

    public class Tag : BaseDeletableModel<int>
    {
        public Tag()
        {
            this.Images = new HashSet<Image>();
        }

        [Required]
        public string BulgarianName { get; set; }

        [Required]
        public string EnglishName { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
