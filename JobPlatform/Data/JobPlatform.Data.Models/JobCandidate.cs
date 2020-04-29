namespace JobPlatform.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class JobCandidate
    {
        [Key]
        public string JobId { get; set; }

        public virtual Job Job { get; set; }

        [Key]
        public string CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
