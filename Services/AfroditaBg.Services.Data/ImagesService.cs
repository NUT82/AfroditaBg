namespace AfroditaBg.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AfroditaBg.Data.Common.Repositories;
    using AfroditaBg.Data.Models;
    using AfroditaBg.Services.Mapping;
    using AfroditaBg.Web.ViewModels.Administration.Gallery;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Hosting;

    public class ImagesService : IImagesService
    {
        private readonly string[] allowedExtensions = new[] { ".jpg", ".png", ".gif" };
        private readonly IDeletableEntityRepository<Image> imageRepository;
        private readonly ITagsService tagsService;
        private readonly IHostEnvironment environment;

        public ImagesService(IDeletableEntityRepository<Image> imageRepository, ITagsService tagsService, IHostEnvironment environment)
        {
            this.imageRepository = imageRepository;
            this.tagsService = tagsService;
            this.environment = environment;
        }

        public async Task<string> AddNewImageAsync(IFormFile image, string imagePath, params string[] allowedExtensions)
        {
            if (allowedExtensions.Length == 0)
            {
                allowedExtensions = this.allowedExtensions;
            }

            var extension = Path.GetExtension(image.FileName).ToLower();
            if (!allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                throw new Exception($"Invalid image extension {extension}");
            }

            bool inGallery = imagePath.Contains("gallery");
            var dbImage = new Image
            {
                Extension = extension,
                InGallery = inGallery,
            };

            await this.imageRepository.AddAsync(dbImage);
            await this.imageRepository.SaveChangesAsync();

            var physicalPath = $"{imagePath}{dbImage.Id}{extension}";
            using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
            await image.CopyToAsync(fileStream);
            return dbImage.Id;
        }

        public async Task AddNewImageToGalleryAsync(GalleryInputViewModel viewModel)
        {
            var imageId = await this.AddNewImageAsync(viewModel.Image, $"{this.environment.ContentRootPath}/wwwroot/images/gallery/");
            var image = this.imageRepository.All().Where(x => x.Id == imageId).FirstOrDefault();

            var bulgarianTags = viewModel.BulgarianTag?.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
            var englishTags = viewModel.EnglishTag?.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

            if (bulgarianTags != null)
            {
                for (int i = 0; i < bulgarianTags.Count; i++)
                {
                    var tag = await this.tagsService.AddNewTagAsync(bulgarianTags[i], englishTags[i]);
                    image.Tags.Add(tag);
                }
            }

            image.Description = viewModel.BulgarianDescription;
            image.ModelName = viewModel.ModelName;
            await this.imageRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAllImagesInGallery<T>(int page) => this.imageRepository.AllAsNoTracking().Where(x => x.InGallery).To<T>().Skip((page - 1) * 6).Take(6).ToList();

        public IEnumerable<T> GetAllImagesByTagInGallery<T>(int page, string tag) => this.imageRepository.AllAsNoTracking().Where(x => x.InGallery && x.Tags.Any(t => t.BulgarianName == tag)).To<T>().Skip((page - 1) * 6).Take(6).ToList();

        public async Task RemoveImageAsync(string id)
        {
            var link = this.imageRepository.All().Where(i => i.Id == id).FirstOrDefault();
            this.imageRepository.Delete(link);
            await this.imageRepository.SaveChangesAsync();
        }

        public int GetCountAllImagesByTagInGallery(string tag) => this.imageRepository.AllAsNoTracking().Where(x => x.InGallery && x.Tags.Any(t => t.BulgarianName == tag)).Count();

        public int GetCountAllImagesInGallery() => this.imageRepository.AllAsNoTracking().Where(x => x.InGallery).Count();

        public IEnumerable<T> GetRandomImagesFromGallery<T>(int count) => this.imageRepository.AllAsNoTracking().Where(x => x.InGallery).To<T>().OrderBy(x => Guid.NewGuid()).Take(count).ToList();
    }
}
