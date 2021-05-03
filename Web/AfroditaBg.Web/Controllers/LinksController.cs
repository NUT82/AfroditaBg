namespace AfroditaBg.Web.Controllers
{
    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels.Links;
    using Microsoft.AspNetCore.Mvc;

    public class LinksController : BaseController
    {
        private readonly ILinksService linksService;

        public LinksController(ILinksService linksService)
        {
            this.linksService = linksService;
        }

        public IActionResult Index()
        {
            var viewModel = this.linksService.GetAll<LinkViewModel>();
            return this.View(viewModel);
        }
    }
}
