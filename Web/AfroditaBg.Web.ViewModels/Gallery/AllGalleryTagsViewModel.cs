namespace AfroditaBg.Web.ViewModels.Gallery
{
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;

    public class AllGalleryTagsViewModel : IMapFrom<Tag>
    {
        public string BulgarianName { get; set; }

        public string EnglishName { get; set; }
    }
}
