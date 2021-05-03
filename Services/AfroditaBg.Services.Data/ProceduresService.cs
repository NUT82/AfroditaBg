namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AfroditaBg.Data.Common.Repositories;
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;
    using AfroditaBg.Web.ViewModels.Administration.Procedures;
    using Microsoft.Extensions.Hosting;

    public class ProceduresService : IProceduresService
    {
        private readonly IDeletableEntityRepository<Procedure> proceduresRepository;
        private readonly IImagesService imagesService;
        private readonly IHostEnvironment environment;

        public ProceduresService(IDeletableEntityRepository<Procedure> proceduresRepository, IImagesService imagesService, IHostEnvironment environment)
        {
            this.proceduresRepository = proceduresRepository;
            this.imagesService = imagesService;
            this.environment = environment;
        }

        public int GetCount()
        {
            return this.proceduresRepository.AllAsNoTracking().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.proceduresRepository.AllAsNoTracking().To<T>().ToList();
        }

        public IEnumerable<T> GetAllNames<T>() => this.proceduresRepository.AllAsNoTracking().OrderByDescending(x => x.CreatedOn).To<T>().ToList();

        public T GetProcedure<T>(string name) => this.proceduresRepository.AllAsNoTracking().Where(p => p.EnglishName == name).To<T>().FirstOrDefault();

        public async Task AddNewProcedureAsync(ProcedureInputViewModel viewModel)
        {
            var thumbnailImageId = await this.imagesService.AddNewImageAsync(viewModel.ThumbnailImage, $"{this.environment.ContentRootPath}/wwwroot/images/procedures/", ".png");
            var imageId = await this.imagesService.AddNewImageAsync(viewModel.Image, $"{this.environment.ContentRootPath}/wwwroot/images/procedures/");

            var procedure = new Procedure
            {
                BulgarianName = viewModel.BulgarianName,
                BulgarianDescription = viewModel.BulgarianDescription,
                EnglishName = viewModel.EnglishName,
                EnglishDescription = viewModel.EnglishDescription,
                ImageId = imageId,
                ThumbnailImageId = thumbnailImageId,
            };

            await this.proceduresRepository.AddAsync(procedure);
            await this.proceduresRepository.SaveChangesAsync();
        }

        public async Task RemoveProcedureAsync(int id)
        {
            var link = this.proceduresRepository.All().Where(i => i.Id == id).FirstOrDefault();
            this.proceduresRepository.HardDelete(link);
            await this.proceduresRepository.SaveChangesAsync();
        }
    }
}
