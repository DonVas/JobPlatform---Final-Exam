namespace JobPlatform.Web.ViewModels.Company
{
    using System.Collections.Generic;

    using JobPlatform.Services.Mapping;
    using JobPlatform.Web.ViewModels.Jobs;

    public class CompanySimpleViewModel : IMapFrom<Data.Models.Company>
    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        public string LogoPicture { get; set; }
    }
}
