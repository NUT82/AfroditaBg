﻿namespace AfroditaBg.Web.ViewModels.Procedures
{
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;

    public class AllProceduresNamesViewModel : IMapFrom<Procedure>
    {
        public string BulgarianName { get; set; }

        public string EnglishName { get; set; }
    }
}
