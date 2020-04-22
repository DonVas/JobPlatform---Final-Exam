namespace JobPlatform.Services.Data.Interfaces
{
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;
    using JobPlatform.Data.Models;
    using Microsoft.AspNetCore.Http;

    public interface IFileService
    {
        Task<DelResResult> DeleteFileAsync(string publicId);

        Task<ImageUploadResult> UploadProfileImageAsync(IFormFile file, string userId);

        Task<ImageUploadResult> UploadImageFileAsync(IFormFile file, string userId, string fileName);
    }
}
