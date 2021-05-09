namespace AfroditaBg.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AfroditaBg.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        public Comment()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string CommentBody { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}
