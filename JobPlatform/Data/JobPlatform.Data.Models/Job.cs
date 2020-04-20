using System;
using System.Collections.Generic;
using JobPlatform.Data.Models.Enums;

namespace JobPlatform.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using JobPlatform.Data.Common.Models;

    public class Job : BaseDeletableModel<string>
    {
        public Job()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [EmailAddress]
        [Required]
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

        [Required]
        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<JobCandidate> Candidates { get; set; } = new HashSet<JobCandidate>();
    }
}
