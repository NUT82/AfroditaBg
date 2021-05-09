namespace AfroditaBg.Web.ViewModels.Blog
{
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;

    public class BlogViewModel : IMapFrom<Blog>
    {
        public string ModelName { get; set; }

        public string Id { get; set; }

        public string Extension { get; set; }

        public string Description { get; set; }

        public string ImagePath => $"/images/gallery/{this.Id}{this.Extension}";
    }
}
