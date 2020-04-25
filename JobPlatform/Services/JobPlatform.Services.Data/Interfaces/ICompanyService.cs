namespace JobPlatform.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using JobPlatform.Data.Models;

    public interface ICompanyService
    {
        IEnumerable<T> GetAllCompanies<T>();

        Task<int> AddCompany(string companyName, string companyDescription, string companyWebsite, string facebookWebsite, string twitterWebsite, string linkedInWebsite, string logoPicture, string userId);

        Task<int> EditCompany(string companyName, string companyDescription, string companyWebsite, string facebookWebsite, string twitterWebsite, string linkedInWebsite, string logoPicture, string firmId);

        T CompanyById<T>(string id);

        T CompanyByUserId<T>(string id);

        Task<bool> DeleteById(string id);

        Company CompanyByUserId(string id);
    }
}
