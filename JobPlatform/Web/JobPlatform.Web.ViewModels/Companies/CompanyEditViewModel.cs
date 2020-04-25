namespace JobPlatform.Web.ViewModels.Companies
{
    using System.ComponentModel.DataAnnotations;
    using System.Diagnostics.CodeAnalysis;

    using Ganss.XSS;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;
    using JobPlatform.Web.Infrastructure;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class CompanyEditViewModel : IMapFrom<Company>, IMapTo<Company>
    {
        public string Id { get; set; }

        [StringLength(100)]
        [Required]
        public string CompanyName { get; set; }

        [StringLength(100000)]
        [Required]
        public string CompanyDescription { get; set; }

        public string SanitizedCompanyDescription => new HtmlSanitizer().Sanitize(this.CompanyDescription);

        [Url]
        public string CompanyWebsite { get; set; }

        [Url]
        public string FacebookWebsite { get; set; }

        [Url]
        public string TwitterWebsite { get; set; }

        [Url]
        public string LinkedInWebsite { get; set; }

        [Url]
        public string LogoPicture { get; set; }

        [BindProperty]
        [AllowNull]
        [DataType(DataType.Upload)]
        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile PictureFile { get; set; }
    }
}
