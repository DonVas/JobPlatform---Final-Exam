namespace JobPlatform.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using JobPlatform.Data.Common.Models;

    public class Candidate : BaseDeletableModel<string>
    {
        [Required]
        public string Cv { get; set; }

        public string MotivationLetter { get; set; }

        public virtual ICollection<JobCandidate> Jobs { get; set; } = new HashSet<JobCandidate>();

        [Required]
        public virtual ApplicationUser User { get; set; }
    }
}
