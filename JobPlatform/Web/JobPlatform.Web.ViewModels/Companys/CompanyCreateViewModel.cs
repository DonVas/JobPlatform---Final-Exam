namespace JobPlatform.Web.ViewModels.Company
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class CompanyCreateViewModel : IMapFrom<Company>, IMapTo<Company>
    {
        [StringLength(100)]
        public string CompanyName { get; set; }

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
    }
}
