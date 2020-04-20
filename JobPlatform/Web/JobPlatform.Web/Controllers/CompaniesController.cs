namespace JobPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Web.ViewModels.Company;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Moderator, Employer")]
    public class CompaniesController : BaseController
    {
        private readonly ICompanyService companyService;
        private readonly UserManager<ApplicationUser> userManager;

        public CompaniesController(
            ICompanyService companyService,
            UserManager<ApplicationUser> userManager)
        {
            this.companyService = companyService;
            this.userManager = userManager;
        }

        public IActionResult Company()
        {
            var viewModel = new CompanyCreateViewModel();
            return this.View(viewModel);
        }

        public IActionResult CreateCompany()
        {
            var viewModel = new CompanyCreateViewModel();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyCreateViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            this.companyService.AddCompany(input, user.Id);

            return this.View();
        }

        public IActionResult Companies()
        {
            var viewModel = this.companyService.GetAllCompanies<CompanySimpleViewModel>();

            return this.View(viewModel);
        }

        public IActionResult DeleteCompany()
        {
            var viewModel = new List<CompanySimpleViewModel>();

            return this.View(viewModel);
        }

        public IActionResult DetailsCompany()
        {
            var viewModel = new List<CompanySimpleViewModel>();

            return this.View(viewModel);
        }

        public IActionResult EditCompany()
        {
            var viewModel = new List<CompanySimpleViewModel>();

            return this.View(viewModel);
        }
    }
}
