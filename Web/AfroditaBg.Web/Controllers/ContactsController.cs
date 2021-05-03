namespace AfroditaBg.Web.Controllers
{
    using System;
    using System.Diagnostics;

    using AfroditaBg.Web.ViewModels;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;

    public class ContactsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
