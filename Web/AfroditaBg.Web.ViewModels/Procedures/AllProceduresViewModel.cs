namespace AfroditaBg.Web.ViewModels.Procedures
{
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;

    public class AllProceduresViewModel : IMapFrom<Procedure>
    {
        public int Id { get; set; }

        public string BulgarianName { get; set; }

        public string EnglishName { get; set; }

        public string BulgarianDescription { get; set; }

        public string BulgarianDescriptionShort => this.BulgarianDescription.Substring(0, 180) + "...";

        public string ThumbnailImageId { get; set; }

        public string ThumbnailImagePath => $"/images/procedures/{this.ThumbnailImageId}.png";
    }
}
