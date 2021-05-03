namespace AfroditaBg.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AfroditaBg.Data.Common.Models;

    public class Image : BaseDeletableModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Tags = new HashSet<Tag>();
        }

        [Required]
        public string Extension { get; set; }

        public string Description { get; set; }

        public string ModelName { get; set; }

        public int? Rating { get; set; }

        public bool InGallery { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
