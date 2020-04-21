using JobPlatform.Web.ViewModels.Companies;
using Microsoft.AspNetCore.Http;

namespace JobPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Web.ViewModels.Companies;
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

        [HttpPost]
        public void UploadFile(IFormFile pictureFile)
        {

        }

        public IActionResult Index()
        {
            var viewModel = this.companyService.GetAllCompanies<CompanySimpleViewModel>();

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Company(string id)
        {
            var viewModel = this.companyService.CompanyById<CompanyViewModel>(id);

            return this.View(viewModel);
        }

        public IActionResult CreateCompany()
        {
            var viewDummy = new CompanyCreateViewModel();

            return this.View(viewDummy);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyCreateViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var result = this.companyService.AddCompany(
                input.CompanyName,
                input.CompanyDescription,
                input.CompanyWebsite,
                input.FacebookWebsite,
                input.TwitterWebsite,
                input.LinkedInWebsite,
                input.LogoPicture,
                user.Id).Result;
            if (result != 1)
            {
                return this.NotFound();
            }

            return this.Redirect("/Companies/Companies");
        }

        [HttpDelete]
        public IActionResult DeleteCompany()
        {
            var viewModel = new List<CompanySimpleViewModel>();

            return this.View(viewModel);
        }

        [HttpPatch]
        public IActionResult EditCompany()
        {
            var viewModel = new List<CompanySimpleViewModel>();

            return this.View(viewModel);
        }
    }
}
