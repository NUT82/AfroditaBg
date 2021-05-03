namespace AfroditaBg.Web.Components
{
    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels.Procedures;
    using Microsoft.AspNetCore.Mvc;

    [ViewComponent(Name = "AllProcedures")]
    public class AllProceduresNamesViewComponent : ViewComponent
    {
        private readonly IProceduresService proceduresService;

        public AllProceduresNamesViewComponent(IProceduresService proceduresService)
        {
            this.proceduresService = proceduresService;
        }

        public IViewComponentResult Invoke()
        {
            var procedures = this.proceduresService.GetAllNames<AllProceduresNamesViewModel>();
            var viewModel = new AllProceduresNamesComponentViewModel { Procedures = procedures };
            return this.View(viewModel);
        }
    }
}
