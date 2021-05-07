namespace AfroditaBg.Web.ViewModels.Procedures
{
    using System.Linq;

    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;

    public class ProcedureViewModel : IMapFrom<Procedure>
    {
        public string BulgarianName { get; set; }

        public string ImageId { get; set; }

        public string ImageExtension { get; set; }

        public string BulgarianDescription { get; set; }

        public string[] BulgarianDescriptionByRows => this.BulgarianDescription.Split("\n").ToArray();

        public int Id { get; set; }

        public string ImagePath => $"/images/procedures/{this.ImageId}{this.ImageExtension}";
    }
}
