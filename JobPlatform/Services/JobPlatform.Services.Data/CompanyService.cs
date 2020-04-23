using System.Threading.Tasks;

namespace JobPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using JobPlatform.Data.Common.Repositories;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class CompanyService : ICompanyService
    {
        private readonly IDeletableEntityRepository<Company> companyRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public CompanyService(
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

        public T CompanyById<T>(string id)
        {
            return this.companyRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();
        }

        public T CompanyByUserId<T>(string id)
        {
            return this.companyRepository.All().Where(x => x.UserId == id).To<T>().FirstOrDefault();
        }
    }
}
