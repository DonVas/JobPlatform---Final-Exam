namespace JobPlatform.Services.Data
{
    using System;
    using System.Threading.Tasks;

    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Http;

    public interface IFileService
    {
        string UploadFileAsync(string file);

        Task<ImageUploadResult> UploadImageAsync(IFormFile file);
    }
}
