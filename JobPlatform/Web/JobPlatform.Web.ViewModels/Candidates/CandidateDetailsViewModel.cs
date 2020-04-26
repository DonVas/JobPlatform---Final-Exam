namespace JobPlatform.Web.ViewModels.Candidates
{
    using System.Net;
    using System.Text.RegularExpressions;

    using Ganss.XSS;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class CandidateDetailsViewModel : IMapFrom<Candidate>
    {
        public string Cv { get; set; }

        public string SanitizeCv
        {
            get
            {
                var sanitize = new HtmlSanitizer().Sanitize(this.Cv);
                return WebUtility.HtmlDecode(Regex.Replace(sanitize, @"<[^>]+>", string.Empty));
            }
        }

        public string MotivationLetter { get; set; }

        public string SanitizeMotivationLetter
        {
            get
            {
                var sanitize = new HtmlSanitizer().Sanitize(this.MotivationLetter);
                return WebUtility.HtmlDecode(Regex.Replace(sanitize, @"<[^>]+>", string.Empty));
            }
        }

        public virtual ApplicationUser User { get; set; }
    }
}
