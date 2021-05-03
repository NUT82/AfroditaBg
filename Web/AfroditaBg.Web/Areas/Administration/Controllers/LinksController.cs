namespace AfroditaBg.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels.Administration.Links;
    using Microsoft.AspNetCore.Mvc;

    public class LinksController : AdministrationController
    {
        private readonly ILinksService linksService;

        public LinksController(ILinksService linksService)
        {
            this.linksService = linksService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(LinkInputViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.linksService.AddNewLinkAsync(viewModel);
            return this.Redirect("~/Links");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await this.linksService.RemoveLinkAsync(id);
            return this.Redirect("~/Links");
        }
    }
}
