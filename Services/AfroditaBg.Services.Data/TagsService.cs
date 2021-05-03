namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AfroditaBg.Data.Common.Repositories;
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;

    public class TagsService : ITagsService
    {
        private readonly IDeletableEntityRepository<Tag> tagRepository;

        public TagsService(IDeletableEntityRepository<Tag> tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        public async Task<Tag> AddNewTagAsync(string bulgarianName, string englishName)
        {
            var tag = this.tagRepository.All().Where(x => x.BulgarianName == bulgarianName).FirstOrDefault();

            if (tag != null)
            {
                return tag;
            }

            var newTag = new Tag
            {
                BulgarianName = bulgarianName,
                EnglishName = englishName,
            };
            await this.tagRepository.AddAsync(newTag);
            await this.tagRepository.SaveChangesAsync();
            return newTag;
        }

        public IEnumerable<T> GetAll<T>() => throw new System.NotImplementedException();

        public IEnumerable<T> GetAllNames<T>() => throw new System.NotImplementedException();

        public int GetCount() => throw new System.NotImplementedException();

        public Task RemoveTagAsync(int id) => throw new System.NotImplementedException();
    }
}
