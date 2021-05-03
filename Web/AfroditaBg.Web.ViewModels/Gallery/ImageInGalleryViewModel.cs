namespace AfroditaBg.Web.ViewModels.Gallery
{
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;

    public class ImageInGalleryViewModel : IMapFrom<Image>
    {
        public string ModelName { get; set; }

        public string Id { get; set; }

        public string Extension { get; set; }

        public string Description { get; set; }

        public string ImagePath => $"/images/gallery/{this.Id}{this.Extension}";
    }
}
