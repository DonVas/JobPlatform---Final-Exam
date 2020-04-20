using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JobPlatform.Data.Common.Repositories;
using JobPlatform.Data.Models;
using JobPlatform.Services.Data.Interfaces;
using JobPlatform.Services.Mapping;
using JobPlatform.Web.ViewModels.Company;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace JobPlatform.Services.Data
{
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

        public async void AddCompany(CompanyCreateViewModel input, string id)
        {
            var company = new Company()
            {
                CompanyName = input.CompanyName,
                CompanyDescription = input.CompanyDescription,
                CompanyWebsite = input.CompanyWebsite,
                FacebookWebsite = input.FacebookWebsite,
                TwitterWebsite = input.TwitterWebsite,
                LinkedInWebsite = input.LinkedInWebsite,
                LogoPicture = input.LogoPicture,
                UserId = id,
            };

            await this.companyRepository.AddAsync(company);
            await this.companyRepository.SaveChangesAsync();
        }
    }
}
