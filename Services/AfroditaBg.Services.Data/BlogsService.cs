namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AfroditaBg.Data.Common.Repositories;
    using AfroditaBg.Data.Models;
    using AfroditaBg.Web.ViewModels.Administration.Blog;
    using Microsoft.Extensions.Hosting;

    public class BlogsService : IBlogsService
    {
        private readonly IImagesService imagesService;
        private readonly IHostEnvironment environment;
        private readonly ICategoriesService categoriesService;
        private readonly IDeletableEntityRepository<Blog> blogRepository;

        public BlogsService(IImagesService imagesService, IHostEnvironment environment, ICategoriesService categoriesService, IDeletableEntityRepository<Blog> blogRepository)
        {
            this.imagesService = imagesService;
            this.environment = environment;
            this.categoriesService = categoriesService;
            this.blogRepository = blogRepository;
        }

        public async Task AddNewBlogAsync(BlogInputViewModel viewModel, string userId)
        {
            Category category;
            if (viewModel.SelectCategory == "new")
            {
                category = await this.categoriesService.AddNewCategoryAsync(viewModel.NewCategory);
            }
            else
            {
                category = await this.categoriesService.AddNewCategoryAsync(viewModel.SelectCategory);
            }

            var blog = new Blog
            {
                BulgarianTitle = viewModel.BulgarianTitle,
                BulgarianDescription = viewModel.BulgarianDescription,
                UserId = userId,
                Category = category,
            };

            foreach (var image in viewModel.Images)
            {
                var currImage = await this.imagesService.AddNewImageAsync(image, $"{this.environment.ContentRootPath}/wwwroot/images/blog/");
                blog.Images.Add(currImage);
            }

            await this.blogRepository.AddAsync(blog);
            await this.blogRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>()
        {
            throw new System.NotImplementedException();
        }

        public T GetBlog<T>(string title)
        {
            throw new System.NotImplementedException();
        }

        public int GetCount()
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveBlogAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
