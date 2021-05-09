namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AfroditaBg.Data.Models;

    public interface ICategoriesService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        IEnumerable<string> GetAllTitles();

        Task<Category> AddNewCategoryAsync(string bulgarianTitle);

        Task RemoveCategoryAsync(int id);

        Category GetCategoryByTitle(string bulgarianTitle);
    }
}
