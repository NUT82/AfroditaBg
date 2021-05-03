namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AfroditaBg.Web.ViewModels.Administration.Links;

    public interface ILinksService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        Task AddNewLinkAsync(LinkInputViewModel viewModel);

        Task RemoveLinkAsync(int id);
    }
}
