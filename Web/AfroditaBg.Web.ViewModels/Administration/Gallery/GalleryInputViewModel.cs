namespace AfroditaBg.Web.ViewModels.Administration.Gallery
{
    using Microsoft.AspNetCore.Http;

    public class GalleryInputViewModel
    {
        public string BulgarianTag { get; set; }

        public string EnglishTag { get; set; }

        public string BulgarianDescription { get; set; }

        public string EnglishDescription { get; set; }

        public string ModelName { get; set; }

        public IFormFile Image { get; set; }
    }
}
