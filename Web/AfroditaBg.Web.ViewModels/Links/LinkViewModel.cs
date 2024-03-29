﻿namespace AfroditaBg.Web.ViewModels.Links
{
    using System.Linq;

    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;

    public class LinkViewModel : IMapFrom<Link>
    {
        public string BulgarianTitle { get; set; }

        public string ImageId { get; set; }

        public string ImageExtension { get; set; }

        public string BulgarianDescription { get; set; }

        public string[] BulgarianDescriptionByRows => this.BulgarianDescription.Split("\n").ToArray();

        public string ImagePath => $"/images/links/{this.ImageId}{this.ImageExtension}";

        public string Url { get; set; }

        public int Id { get; set; }
    }
}
