namespace JobPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet.Actions;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class FileController : BaseController
    {
        private readonly IFileService fileService;

        public FileController(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public async Task<ImageUploadResult> UploadImageAsync(IFormFile file, ApplicationUser user)
        {
            //this.User.Claims.FirstOrDefault(x => x.Properties.ContainsKey("ProfilePicture"));
            //var uploadResult = await this.fileService.UploadProfileImageAsync(file);

            //if (uploadResult != null)
            //{
            //    return uploadResult;
            //}

            return null;
        }
    }
}
