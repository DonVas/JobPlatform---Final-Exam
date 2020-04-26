namespace JobPlatform.Web.ViewModels.Companies
{
    using System.Collections.Generic;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;
    using JobPlatform.Web.ViewModels.Jobs;

    public class CompanyByIdViewModel : IMapFrom<Company>
    {
        public string CompanyName { get; set; }

        public string FacebookWebsite { get; set; }

        public string TwitterWebsite { get; set; }

        public string LinkedInWebsite { get; set; }

        public string LogoPicture { get; set; }

        public virtual ICollection<JobSimpleViewModel> Jobs { get; set; }
    }
}
