namespace JobPlatform.Web.ViewModels.Candidates
{
    using System.Net;
    using System.Text.RegularExpressions;

    using Ganss.XSS;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class CandidateSimpleViewModel : IMapFrom<Candidate>
    {
        public string Cv { get; set; }

        public string ShortSanitizeCv
        {
            get
            {
                var sanitizeText = new HtmlSanitizer().Sanitize(this.Cv);
                var content = WebUtility.HtmlDecode(Regex.Replace(sanitizeText, @"<[^>]+>", string.Empty));
                return content.Length > 200
                    ? content.Substring(0, 200) + "..."
                    : content;
            }
        }

        public string MotivationLetter { get; set; }

        public string ShortSanitizeMotivationLetter
        {
            get
            {
                var sanitizeText = new HtmlSanitizer().Sanitize(this.MotivationLetter);
                var content = WebUtility.HtmlDecode(Regex.Replace(sanitizeText, @"<[^>]+>", string.Empty));
                return content.Length > 200
                    ? content.Substring(0, 200) + "..."
                    : content;
            }
        }

        public virtual ApplicationUser User { get; set; }
    }
}
