namespace AfroditaBg.Web.Controllers
{
    using System;
    using System.Diagnostics;

    using AfroditaBg.Services.Data;
    using AfroditaBg.Web.ViewModels;
    using AfroditaBg.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IImagesService imagesService;

        public HomeController(IImagesService imagesService)
        {
            this.imagesService = imagesService;
        }

        public IActionResult Index()
        {
            var viewModel = this.imagesService.GetRandomImagesFromGallery<IndexViewModel>(2);
            return this.View(viewModel);
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            this.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return this.LocalRedirect(returnUrl);
        }
    }
}
