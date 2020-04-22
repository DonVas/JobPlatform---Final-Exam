using System.Collections.Generic;
using AutoMapper;
using JobPlatform.Data.Common.Models;

namespace JobPlatform.Web.ViewModels.Companies
{

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class CompanyViewModel : IMapFrom<Company>, IHaveCustomMappings
    {
        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        public string CompanyWebsite { get; set; }

        public string FacebookWebsite { get; set; }

        public string TwitterWebsite { get; set; }

        public string LinkedInWebsite { get; set; }

        public string LogoPicture { get; set; }

        public virtual ICollection<Job> Jobs { get; set; } = new HashSet<Job>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<CompanyViewModel, File>()
                .ForMember(x => x.FileLink, options =>
                {
                    options.MapFrom(p => p.LogoPicture);
                });
        }
    }
}
