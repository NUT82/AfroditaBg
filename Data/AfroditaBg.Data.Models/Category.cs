namespace AfroditaBg.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using AfroditaBg.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }
    }
}
