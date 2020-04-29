using System;

namespace JobPlatform.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using JobPlatform.Data.Common.Models;

    public class Candidate : BaseDeletableModel<string>
    {
        public Candidate()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public Candidate(string cv, string motivationLetter, string userId)
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cv = cv;
            this.MotivationLetter = motivationLetter;
            this.UserId = userId;
        }

        [Required]
        public string Cv { get; set; }

        public string MotivationLetter { get; set; }

        public virtual ICollection<JobCandidate> Jobs { get; set; } = new HashSet<JobCandidate>();

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
