namespace AfroditaBg.Web.ViewModels.Gallery
{
    using System.Collections.Generic;

    public class GalleryViewModel
    {
        public IEnumerable<ImageInGalleryViewModel> Images { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public Page Page { get; set; }
    }
}
