namespace AfroditaBg.Web.Areas.Administration.Controllers
{
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels.Administration.Blog;
    using Microsoft.AspNetCore.Mvc;

    public class BlogController : AdministrationController
    {
        private readonly ICategoriesService categoriesService;
        private readonly IBlogsService blogsService;

        public BlogController(ICategoriesService categoriesService, IBlogsService blogsService)
        {
            this.categoriesService = categoriesService;
            this.blogsService = blogsService;
        }

        public IActionResult Add()
        {
            var categories = this.categoriesService.GetAllTitles();
            var viewModel = new BlogInputViewModel
            {
                Categories = categories,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BlogInputViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.blogsService.AddNewBlogAsync(viewModel, this.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return this.Redirect("~/Blog");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id, int currPage)
        {
            await this.blogsService.RemoveBlogAsync(id);
            return this.Redirect("~/Blog?page=" + currPage);
        }
    }
}
