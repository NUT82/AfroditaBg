namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AfroditaBg.Web.ViewModels.Administration.Blog;

    public interface IBlogsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        T GetBlog<T>(string title);

        Task AddNewBlogAsync(BlogInputViewModel viewModel, string userId);

        Task RemoveBlogAsync(int id);
    }
}
