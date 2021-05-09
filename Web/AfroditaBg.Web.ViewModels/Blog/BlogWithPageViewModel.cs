namespace AfroditaBg.Web.ViewModels.Blog
{
    using System.Collections.Generic;

    public class BlogWithPageViewModel
    {
        public IEnumerable<BlogViewModel> Blogs { get; set; }

        public Page Page { get; set; }
    }
}
