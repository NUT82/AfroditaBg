namespace AfroditaBg.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AfroditaBg.Data.Common.Models;

    public class Blog : BaseDeletableModel<int>
    {
        public Blog()
        {
            this.Images = new HashSet<Image>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string BulgarianTitle { get; set; }

        [Required]
        public string BulgarianDescription { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        public ICollection<Image> Images { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
