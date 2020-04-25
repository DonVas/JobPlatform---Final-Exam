namespace JobPlatform.Web.ViewModels.Jobs
{

    using Ganss.XSS;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class JobDetailsViewModel : IMapFrom<Job>
    {
        public string Id { get; set; }

        public string CompanyEmail { get; set; }

        public string JobTitle { get; set; }

        public string JobCategory { get; set; }

        public string LocationCity { get; set; }

        public string JobType { get; set; }

        public string Description { get; set; }

        public string SanitizedDescription => new HtmlSanitizer().Sanitize(this.Description);
    }
}
