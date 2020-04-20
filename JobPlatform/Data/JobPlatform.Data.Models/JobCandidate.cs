namespace JobPlatform.Data.Models
{
    public class JobCandidate
    {
        public string JobId { get; set; }

        public virtual Job Job { get; set; }

        public string CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
