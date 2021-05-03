namespace AfroditaBg.Web.Areas.Administration.Controllers
{
    using AfroditaBg.Common;
    using AfroditaBg.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
