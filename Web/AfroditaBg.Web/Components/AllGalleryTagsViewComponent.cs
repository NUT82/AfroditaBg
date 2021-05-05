namespace AfroditaBg.Web.Components
{
    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels.Gallery;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "AllGalleryTags")]
    public class AllGalleryTagsViewComponent : ViewComponent
    {
        private readonly ITagsService tagsService;

        public AllGalleryTagsViewComponent(ITagsService tagsService)
        {
            this.tagsService = tagsService;
        }

        public IViewComponentResult Invoke()
        {
            var tags = this.tagsService.GetAll<AllGalleryTagsViewModel>();
            var viewModel = new AllGalleryTagsComponentViewModel { GalleryTags = tags };
            return this.View(viewModel);
        }
    }
}
