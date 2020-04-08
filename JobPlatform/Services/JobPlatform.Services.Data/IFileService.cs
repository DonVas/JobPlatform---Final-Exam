namespace JobPlatform.Services.Data
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public interface IFileService
    {
        Task UploadFileAsync(IFormFile file);
    }
}
