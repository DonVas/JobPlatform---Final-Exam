namespace JobPlatform.Services.Data
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using System.Web;

    using JobPlatform.Data.Common.Models;
    using JobPlatform.Data.Common.Repositories;
    using Microsoft.AspNetCore.Http;

    public class FileService : IFileService
{
        private readonly IDeletableEntityRepository<FileTable> fileRepository;

        public FileService(IDeletableEntityRepository<FileTable> fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        //public void Upload(object sender)
        //{
        //    string base64 = Request.Form["imgCropped"];
        //    byte[] bytes = Convert.FromBase64String(base64.Split(',')[1]);
        //    using (System.IO.FileStream stream = new System.IO.FileStream(Server.MapPath("~/Images/Cropped.png"), System.IO.FileMode.Create))
        //    {
        //        stream.Write(bytes, 0, bytes.Length);
        //        stream.Flush();
        //    }
        //}

        public async Task UploadFileAsync(IFormFile file)
        {
            if (file != null)
            {
                byte[] data = this.GetBytesFromFile(file);
                await this.fileRepository.AddAsync(new FileTable() { Name = Guid.NewGuid().ToString(), UploadedFile = data });
            }
        }

        private byte[] GetBytesFromFile(IFormFile file)
        {
            using (Stream inputStream = file.OpenReadStream())
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }

                return memoryStream.ToArray();
            }
        }
    }
}
