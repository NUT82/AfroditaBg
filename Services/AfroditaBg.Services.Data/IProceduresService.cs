namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AfroditaBg.Web.ViewModels.Administration.Procedures;

    public interface IProceduresService
    {
        int GetCount();

        IEnumerable<T> GetAll<T>();

        IEnumerable<T> GetAllNames<T>();

        T GetProcedure<T>(string name);

        Task AddNewProcedureAsync(ProcedureInputViewModel viewModel);

        Task RemoveProcedureAsync(int id);
    }
}
