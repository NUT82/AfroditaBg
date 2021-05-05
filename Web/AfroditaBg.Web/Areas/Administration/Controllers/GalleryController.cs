namespace AfroditaBg.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels.Administration.Gallery;
    using Microsoft.AspNetCore.Mvc;

    public class GalleryController : AdministrationController
    {
        private readonly IImagesService imagesService;
        private readonly ITagsService tagsService;

        public GalleryController(IImagesService imagesService, ITagsService tagsService)
        {
            this.imagesService = imagesService;
            this.tagsService = tagsService;
        }

        public IActionResult Add()
        {
            var tags = this.tagsService.GetAllNames();
            var viewModel = new GalleryInputViewModel
            {
                Tags = tags,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(GalleryInputViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.imagesService.AddNewImageToGalleryAsync(viewModel);
            return this.Redirect("~/Gallery");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string id, int currPage)
        {
            await this.imagesService.RemoveImageAsync(id);
            return this.Redirect("~/Gallery?page=" + currPage);
        }
    }
}
