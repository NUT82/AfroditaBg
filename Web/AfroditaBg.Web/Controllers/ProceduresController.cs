namespace AfroditaBg.Web.Controllers
{
    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels.Procedures;
    using Microsoft.AspNetCore.Mvc;

    public class ProceduresController : BaseController
    {
        private readonly IProceduresService proceduresService;

        public ProceduresController(IProceduresService proceduresService)
        {
            this.proceduresService = proceduresService;
        }

        public IActionResult AllProcedures()
        {
            var viewModel = this.proceduresService.GetAll<AllProceduresViewModel>();
            return this.View(viewModel);
        }

        public IActionResult Procedures(string procedure)
        {
            var viewModel = this.proceduresService.GetProcedure<ProcedureViewModel>(procedure);
            if (viewModel == null)
            {
                return this.RedirectToAction(nameof(this.AllProcedures));
            }

            return this.View("Procedures", viewModel);
        }
    }
}
