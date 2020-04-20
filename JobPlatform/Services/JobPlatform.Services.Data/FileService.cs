namespace JobPlatform.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using JobPlatform.Data.Common.Models;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data.Interfaces;
    using Microsoft.AspNetCore.Http;

    public class FileService : IFileService
{
    private readonly Cloudinary cloudinary;

    public FileService(Cloudinary cloudinary)
        {
            this.cloudinary = cloudinary;
        }

    public async Task<DelResResult> DeleteFileAsync(string publicId)
        {
            var isPresent = this.IsPresentAsync(publicId).Result;

            DelResResult result = new DelResResult();

            if (isPresent)
            {
                var delResParams = new DelResParams() { PublicIds = new List<string>() { $"{publicId}" } };
                result = await this.cloudinary.DeleteResourcesAsync(delResParams);
            }

            return result;
        }

    public async Task<bool> UploadProfileImageAsync(IFormFile file, ApplicationUser user)
        {
            if (file == null)
            {
                return false;
            }

            var userImageFile = user.UserFiles.FirstOrDefault(x => x.Name == "ProfilePicture");

            if (userImageFile == null)
            {
                var url = await this.Upload(file);
                var userFile = new File() { Name = "ProfilePicture", PublicId = url.PublicId, FileLink = url.SecureUri.ToString()};
                user.UserFiles.Add(userFile);
                user.ProfilePicture = url.SecureUri.ToString();
            }
            else
            {
                var url = await this.Upload(file);

                if (url.SecureUri != null)
                {
                    var delResult = await this.DeleteFileAsync(userImageFile.PublicId);
                    if (delResult.Error == null)
                    {
                        userImageFile.PublicId = url.PublicId;
                        userImageFile.FileLink = url.SecureUri.ToString();
                        user.ProfilePicture = url.SecureUri.ToString();
                    }
                }
                else
                {
                    throw new Exception(message: "Error by uploading");
                }
            }

            return true;
        }

    public Task UploadImageFileAsync(IFormFile file, ApplicationUser user, string fileName)
        {
            throw new NotImplementedException();
        }

    private async Task<ImageUploadResult> Upload(IFormFile file)
        {
            byte[] uploadFile;
            ImageUploadResult result;
            await using (var memoryStream = new System.IO.MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                uploadFile = memoryStream.ToArray();
            }

            await using (var uploadImageStream = new System.IO.MemoryStream(uploadFile))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, uploadImageStream),
                };
                result = await this.cloudinary.UploadAsync(uploadParams);
            }

            return result;
        }

    private async Task<bool> IsPresentAsync(string publicId)
        {
            var result = await this.cloudinary.GetResourceAsync(new GetResourceParams(publicId));

            if (result.Error == null)
            {
                return true;
            }

            return false;
        }
    }
}
