using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using JobPlatform.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace JobPlatform.Services.Data
{
    using System.Threading.Tasks;

    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using JobPlatform.Data.Common.Models;
    using JobPlatform.Data.Common.Repositories;
    using Microsoft.AspNetCore.Http;

    public class FileService : IFileService
{
        private readonly IDeletableEntityRepository<File> fileRepository;
        private readonly Cloudinary cloudinary;
        private readonly UserManager<ApplicationUser> userManager;

        public FileService(
            IDeletableEntityRepository<File> fileRepository,
            Cloudinary cloudinary,
            UserManager<ApplicationUser> userManager)
        {
            this.fileRepository = fileRepository;
            this.cloudinary = cloudinary;
            this.userManager = userManager;
        }

        public async Task<DelResResult> DeleteFileAsync(string publicId)
        {
            var publicIdRegex = @"[\w]{20}";
            var resusrsId = Regex.Match(publicId, publicIdRegex).ToString();

            var delResParams = new DelResParams() { PublicIds = new List<string>() { $"{resusrsId}" } };
            var result = await this.cloudinary.DeleteResourcesAsync(delResParams);
            return result;
        }

        public async Task<bool> UploadProfileImageAsync(IFormFile file, ApplicationUser user)
        {
            if (file == null)
            {
                return false;
            }

            var userImageFile = this.userManager.GetClaimsAsync(user)
                .Result
                .FirstOrDefault(x => x.Type == "ProfilePicture");

            var url = await this.Upload(file);

            if (userImageFile == null)
            {
                var newClime = new Claim("ProfilePicture", url.SecureUri.ToString());
                await this.userManager.AddClaimAsync(user, newClime);
            }
            else
            {
                if (url.SecureUri != null)
                {
                    await this.DeleteFileAsync(userImageFile.Value.ToString());
                    userImageFile.Properties["ProfilePicture"] = url.SecureUri.ToString();
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
            await using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                uploadFile = memoryStream.ToArray();
            }

            await using (var uploadImageStream = new MemoryStream(uploadFile))
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, uploadImageStream),
                };
                result = await this.cloudinary.UploadAsync(uploadParams);
            }

            return result;
        }

        private async Task<bool> IsPresent(string publicId)
        {
            var result = await this.cloudinary.GetResourceAsync(new GetResourceParams(publicId));

            if (result.SecureUrl.ToString() != null)
            {
                return true;
            }

            return false;
        }
    }
}
