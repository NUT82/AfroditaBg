namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AfroditaBg.Data.Common.Repositories;
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category> AddNewCategoryAsync(string bulgarianTitle)
        {
            var category = this.categoryRepository.All().Where(x => x.Title == bulgarianTitle).FirstOrDefault();

            if (category != null)
            {
                return category;
            }

            var newCategory = new Category
            {
                Title = bulgarianTitle,
            };
            await this.categoryRepository.AddAsync(newCategory);
            await this.categoryRepository.SaveChangesAsync();
            return newCategory;
        }

        public IEnumerable<T> GetAll<T>() => this.categoryRepository.AllAsNoTracking().To<T>().ToList();

        public IEnumerable<string> GetAllTitles() => this.categoryRepository.AllAsNoTracking().Select(x => x.Title).ToList();

        public int GetCount() => throw new System.NotImplementedException();

        public Category GetCategoryByTitle(string bulgarianTitle) => this.categoryRepository.AllAsNoTracking().Where(x => x.Title == bulgarianTitle).FirstOrDefault();

        public Task RemoveCategoryAsync(int id) => throw new System.NotImplementedException();
    }
}
