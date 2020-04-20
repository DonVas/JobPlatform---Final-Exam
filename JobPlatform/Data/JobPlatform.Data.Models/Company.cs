namespace JobPlatform.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using JobPlatform.Data.Common.Models;

    public class Company : BaseDeletableModel<string>
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100000)]
        public string CompanyDescription { get; set; }

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

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Job> Jobs { get; set; } = new HashSet<Job>();
    }
}
