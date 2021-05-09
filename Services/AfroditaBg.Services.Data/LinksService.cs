namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AfroditaBg.Data.Common.Repositories;
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;
    using AfroditaBg.Web.ViewModels.Administration.Links;
    using Microsoft.Extensions.Hosting;

    public class LinksService : ILinksService
    {
        private readonly IDeletableEntityRepository<Link> linksRepository;
        private readonly IImagesService imagesService;
        private readonly IHostEnvironment environment;

        public LinksService(IDeletableEntityRepository<Link> linksRepository, IImagesService imagesService, IHostEnvironment environment)
        {
            this.linksRepository = linksRepository;
            this.imagesService = imagesService;
            this.environment = environment;
        }

        public int GetCount()
        {
            return this.linksRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.linksRepository.AllAsNoTracking().OrderByDescending(x => x.CreatedOn).To<T>().ToList();
        }

        public async Task AddNewLinkAsync(LinkInputViewModel viewModel)
        {
            var image = await this.imagesService.AddNewImageAsync(viewModel.Image, $"{this.environment.ContentRootPath}/wwwroot/images/links/");

            var link = new Link
            {
                BulgarianTitle = viewModel.BulgarianTitle,
                EnglishTitle = viewModel.EnglishTitle,
                BulgarianDescription = viewModel.BulgarianDescription,
                EnglishDescription = viewModel.EnglishDescription,
                Url = viewModel.Url,
                Image = image,
            };

            await this.linksRepository.AddAsync(link);
            await this.linksRepository.SaveChangesAsync();
        }

        public async Task RemoveLinkAsync(int id)
        {
            var link = this.linksRepository.All().Where(i => i.Id == id).FirstOrDefault();
            this.linksRepository.HardDelete(link);
            await this.linksRepository.SaveChangesAsync();
        }
    }
}
