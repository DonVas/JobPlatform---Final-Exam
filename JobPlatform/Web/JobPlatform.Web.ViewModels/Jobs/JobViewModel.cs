namespace JobPlatform.Web.ViewModels.Jobs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using JobPlatform.Data.Models;
    using JobPlatform.Data.Models.Enums;
    using JobPlatform.Services.Mapping;

    public class JobViewModel : IMapFrom<Job>
    {
        public string Id { get; set; }

        [EmailAddress]
        public string CompanyEmail { get; set; }

        [StringLength(20)]
        [Required]
        public string JobTitle { get; set; }

        [Required]
        public JobCategory JobCategory { get; set; } = JobCategory.None;

        [Required]
        public LocationCity LocationCity { get; set; } = LocationCity.None;

        [Required]
        public JobType JobType { get; set; } = JobType.FullTime;

        [Required]
        [StringLength(100000)]
        public string Description { get; set; }

        public string CompanyId { get; set; }

        public virtual Data.Models.Company Company { get; set; }

        public virtual ICollection<JobCandidate> Candidates { get; set; }
    }
}
