namespace AfroditaBg.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels.Gallery;
    using Microsoft.AspNetCore.Mvc;

    public class GalleryController : BaseController
    {
        private readonly IImagesService imagesService;
        private readonly ITagsService tagsService;

        public GalleryController(IImagesService imagesService, ITagsService tagsService)
        {
            this.imagesService = imagesService;
            this.tagsService = tagsService;
        }

        public IActionResult Index(string tag, int page = 1)
        {
            var viewModel = new GalleryViewModel();
            viewModel.Tags = new List<string>(this.tagsService.GetAllNames());

            int count;
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
                CurrTag = tag ?? "all",
                TotalPages = (int)Math.Ceiling(count / 6.0),
            };

            return this.View(viewModel);
        }
    }
}
