namespace JobPlatform.Services.Data
{
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;
    using JobPlatform.Data.Models;
    using Microsoft.AspNetCore.Http;

    public interface IFileService
    {
        Task<DelResResult> DeleteFileAsync(string publicId);

        Task<bool> UploadProfileImageAsync(IFormFile file, ApplicationUser user);

        Task UploadImageFileAsync(IFormFile file, ApplicationUser user, string fileName);
    }
}
