namespace AfroditaBg.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using AfroditaBg.Data.Models;
    using AfroditaBg.Web.ViewModels.Administration.Gallery;
    using Microsoft.AspNetCore.Http;

    public interface IImagesService
    {
        public int GetCountAllImagesByTagInGallery(string tag);

        public int GetCountAllImagesInGallery();

        Task<Image> AddNewImageAsync(IFormFile image, string imagePath, params string[] allowedExtensions);

        Task AddNewImageToGalleryAsync(GalleryInputViewModel viewModel);

        Task RemoveImageAsync(string id);

        IEnumerable<T> GetAllImagesInGallery<T>(int page);

        IEnumerable<T> GetAllImagesByTagInGallery<T>(int page, string tag);

        IEnumerable<T> GetRandomImagesFromGallery<T>(int count);
    }
}
