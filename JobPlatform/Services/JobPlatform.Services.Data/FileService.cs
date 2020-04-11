namespace JobPlatform.Services.Data
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Web;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using JobPlatform.Data.Common.Models;
    using JobPlatform.Data.Common.Repositories;
    using Microsoft.AspNetCore.Http;

    public class FileService : IFileService
{
        private readonly IDeletableEntityRepository<FileTable> fileRepository;
        private readonly Cloudinary cloudinary;

        public FileService(IDeletableEntityRepository<FileTable> fileRepository, Cloudinary cloudinary)
        {
            this.fileRepository = fileRepository;
            this.cloudinary = cloudinary;
        }

        public string UploadFileAsync(string file)
        {
            var result = this.cloudinary.DeleteResourcesByTag(file);
            return result.StatusCode.ToString();
        }

        public async Task<ImageUploadResult> UploadImageAsync(IFormFile file)
        {
            if (file == null)
            {
                return null;
            }

            byte[] uploadImage;
            ImageUploadResult result;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                uploadImage = memoryStream.ToArray();
            }

            using (var uploadImageStream = new MemoryStream(uploadImage))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, uploadImageStream),
                };
                result = await this.cloudinary.UploadAsync(uploadParams);
            }

            return result;
        }
    }
}
