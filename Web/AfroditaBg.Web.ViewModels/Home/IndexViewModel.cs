namespace AfroditaBg.Web.ViewModels.Home
{
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;

    public class IndexViewModel : IMapFrom<Image>
    {
        public string Id { get; set; }

        public string Extension { get; set; }

        public string ImagePath => $"/images/gallery/{this.Id}{this.Extension}";
    }
}
