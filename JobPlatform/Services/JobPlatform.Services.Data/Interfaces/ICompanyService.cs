using System.Collections.Generic;
using JobPlatform.Web.ViewModels.Company;

namespace JobPlatform.Services.Data.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<T> GetAllCompanies<T>();

        void AddCompany(CompanyCreateViewModel input, string id);
    }
}
