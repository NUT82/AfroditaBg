namespace AfroditaBg.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels.Administration.Procedures;
    using Microsoft.AspNetCore.Mvc;

    public class ProceduresController : AdministrationController
    {
        private readonly IProceduresService proceduresService;

        public ProceduresController(IProceduresService proceduresService)
        {
            this.proceduresService = proceduresService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProcedureInputViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.proceduresService.AddNewProcedureAsync(viewModel);
            return this.Redirect("~/Procedures");
        }

        [HttpPost]
        public async Task<IActionResult> Remove(int id)
        {
            await this.proceduresService.RemoveProcedureAsync(id);
            return this.Redirect("~/Procedures");
        }
    }
}
