namespace JobPlatform.Web.ViewModels.Jobs
{
    using System.Collections.Generic;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class MyCandidatesViewModel : IMapFrom<Job>
    {
        public string JobTitle { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<JobCandidate> Candidates { get; set; }
    }
}
