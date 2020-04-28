using System.Net;
using System.Text.RegularExpressions;
using Ganss.XSS;

namespace JobPlatform.Web.ViewModels.Jobs
{
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class JobSimpleViewModel : IMapFrom<Job>
    {
        public string Id { get; set; }

        public string CompanyEmail { get; set; }

        public string JobTitle { get; set; }

        public string JobCategory { get; set; }

        public string LocationCity { get; set; }

        public string JobType { get; set; }

        public string Description { get; set; }

        public string SanitizedContent
        {
            get
            {
               var text = new HtmlSanitizer().Sanitize(this.Description);
               text = WebUtility.HtmlDecode(Regex.Replace(text, @"<[^>]+>", string.Empty));
               return text.Length > 200
                   ? text.Substring(0, 200) + "..."
                   : text;
            }
        }

        public string CompanyId { get; set; }

        public string Company { get; set; }
    }
}
