using AutoMapper;
using Ganss.XSS;

namespace JobPlatform.Web.ViewModels.Companies
{
    using System;
    using System.Collections.Generic;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class CompanyDetailsViewModel : IMapTo<Company>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.CompanyDescription);

        public string CompanyWebsite { get; set; }

        public string FacebookWebsite { get; set; }

        public string TwitterWebsite { get; set; }

        public string LinkedInWebsite { get; set; }

        public string LogoPicture { get; set; }

        public string UserId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Company, CompanyDetailsViewModel>().ForMember(
                m => m.Jobs,
                opt => opt.MapFrom(x => x.Jobs));
        }
    }
}
