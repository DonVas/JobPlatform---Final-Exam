using Ganss.XSS;

namespace JobPlatform.Web.ViewModels.Jobs
{
    using System.ComponentModel.DataAnnotations;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class EditJobViewModel : IMapFrom<Job>
    {
        public string Id { get; set; }

        [EmailAddress]
        [Required]
        public string CompanyEmail { get; set; }

        [StringLength(20)]
        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string JobCategory { get; set; }

        [Required]
        public string LocationCity { get; set; }

        [Required]
        public string JobType { get; set; }

        [Required]
        [StringLength(100000)]
        public string Description { get; set; }

    }
}
