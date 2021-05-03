namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AfroditaBg.Data.Models;

    public interface ITagsService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllNames<T>();

        Task<Tag> AddNewTagAsync(string bulgarianName, string englishName);

        Task RemoveTagAsync(int id);
    }
}
