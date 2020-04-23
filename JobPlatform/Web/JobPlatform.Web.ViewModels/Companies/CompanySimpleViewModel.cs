namespace JobPlatform.Web.ViewModels.Companies
{
    using System.Net;
    using System.Text.RegularExpressions;

    using JobPlatform.Services.Mapping;

    public class CompanySimpleViewModel : IMapFrom<Data.Models.Company>
    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyDescription { get; set; }

        public string ShortCompanyDescription
        {
            get
            {
                var content = WebUtility.HtmlDecode(Regex.Replace(this.CompanyDescription, @"<[^>]+>", string.Empty));
                return content.Length > 200
                    ? content.Substring(0, 200) + "..."
                    : content;
            }
        }

        public string LogoPicture { get; set; }
    }
}
