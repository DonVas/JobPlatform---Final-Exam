namespace JobPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobPlatform.Data.Common.Repositories;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Services.Mapping;
    using JobPlatform.Web.ViewModels.Companies;
    using Microsoft.AspNetCore.Identity;

    public class CompaniesService : ICompanyService
    {
        private readonly IDeletableEntityRepository<Company> companyRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public CompaniesService(
            IDeletableEntityRepository<Company> companyRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.companyRepository = companyRepository;
            this.userManager = userManager;
        }

        public IEnumerable<T> GetAllCompanies<T>()
        {
            return this.companyRepository.All().To<T>().ToList();
        }

        public async Task<int> AddCompany(
            string companyName,
            string companyDescription,
            string companyWebsite,
            string facebookWebsite,
            string twitterWebsite,
            string linkedInWebsite,
            string logoPicture,
            string userId)
        {
            var company = new Company()
            {
                CompanyName = companyName,
                CompanyDescription = companyDescription,
                CompanyWebsite = companyWebsite,
                FacebookWebsite = facebookWebsite,
                TwitterWebsite = twitterWebsite,
                LinkedInWebsite = linkedInWebsite,
                LogoPicture = logoPicture,
                UserId = userId,
            };

            await this.companyRepository.AddAsync(company);
            return await this.companyRepository.SaveChangesAsync();
        }

        public async Task<int> EditCompany(
            string companyName,
            string companyDescription,
            string companyWebsite,
            string facebookWebsite,
            string twitterWebsite,
            string linkedInWebsite,
            string logoPicture,
            string id)
        {
            var result = this.companyRepository.All().FirstOrDefault(x => x.Id == id);

            if (result != null)
            {
                result.CompanyName = companyName;
                result.CompanyDescription = companyDescription;
                result.CompanyWebsite = companyWebsite;
                result.FacebookWebsite = facebookWebsite;
                result.TwitterWebsite = twitterWebsite;
                result.LinkedInWebsite = linkedInWebsite;
                if (logoPicture != null)
                {
                    result.LogoPicture = logoPicture;
                }

                this.companyRepository.Update(result);
                return await this.companyRepository.SaveChangesAsync();
            }

            return 0;
        }

        public T CompanyById<T>(string id)
        {
            return this.companyRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
        }

        public T CompanyByUserId<T>(string id)
        {
            return this.companyRepository.All().Where(x => x.UserId == id).To<T>().FirstOrDefault();
        }

        public Company CompanyByUserId(string id)
        {
            return this.companyRepository.All().FirstOrDefault(x => x.UserId == id);
        }

        public string GetCompanyId(string id)
        {
            return this.companyRepository.All().Where(x => x.UserId == id)?.FirstOrDefault()?.Id;
        }

        public async Task<bool> DeleteById(string id)
        {
            var company = this.companyRepository.All().FirstOrDefault(x => x.Id == id);

            if (company != null)
            {
                this.companyRepository.Delete(company);
                await this.companyRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
