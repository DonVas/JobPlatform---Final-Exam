namespace JobPlatform.Web.ViewModels.Jobs
{
    using System.Collections.Generic;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class MyApplicationViewModel : IMapFrom<Job>
    {
        public string CompanyEmail { get; set; }

        public string JobTitle { get; set; }

        public string JobCategory { get; set; }

        public string LocationCity { get; set; }

        public string JobType { get; set; }

        public string Description { get; set; }

        public string CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ICollection<JobCandidate> Candidates { get; set; }
    }
}
