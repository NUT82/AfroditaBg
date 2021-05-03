namespace AfroditaBg.Web.Controllers
{
    using System;

    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels.Gallery;
    using Microsoft.AspNetCore.Mvc;

    public class GalleryController : BaseController
    {
        private readonly IImagesService imagesService;

        public GalleryController(IImagesService imagesService)
        {
            this.imagesService = imagesService;
        }

        public IActionResult Index(string tag, int page = 1)
        {
            var viewModel = new GalleryViewModel();
            var count = 0;

            if (tag == null || tag == "all")
            {
                viewModel.Images = this.imagesService.GetAllImagesInGallery<ImageInGalleryViewModel>(page);
                count = this.imagesService.GetCountAllImagesInGallery();
            }
            else
            {
                viewModel.Images = this.imagesService.GetAllImagesByTagInGallery<ImageInGalleryViewModel>(page, tag);
                count = this.imagesService.GetCountAllImagesByTagInGallery(tag);
            }

            viewModel.Page = new Page
            {
                CurrPage = page,
                TotalPages = (int)Math.Ceiling(count / 6.0),
            };

            return this.View(viewModel);
        }
    }
}
