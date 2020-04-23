namespace JobPlatform.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JobPlatform.Data.Models;

    public interface ICompanyService
    {
        IEnumerable<T> GetAllCompanies<T>();

        Task<int> AddCompany(string companyName, string companyDescription, string companyWebsite, string facebookWebsite, string twitterWebsite, string linkedInWebsite, string logoPicture, string userId);

        T CompanyById<T>(string id);

        T CompanyByUserId<T>(string id);
    }
}
