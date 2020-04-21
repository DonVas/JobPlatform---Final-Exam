namespace JobPlatform.Web.ViewModels.Companies
{

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class CompanyViewModel : IMapFrom<Company>
    {
        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        public string CompanyWebsite { get; set; }

        public string FacebookWebsite { get; set; }

        public string TwitterWebsite { get; set; }

        public string LinkedInWebsite { get; set; }

        public string LogoPicture { get; set; }
    }
}
