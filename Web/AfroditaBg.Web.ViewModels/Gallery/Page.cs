namespace AfroditaBg.Web.ViewModels.Gallery
{
    public class Page
    {
        public int CurrPage { get; set; }

        public string CurrTag { get; set; }

        public int TotalPages { get; set; }

        public bool HasNextPage => this.CurrPage < this.TotalPages;

        public bool HasPrevPage => this.CurrPage > 1;
    }
}