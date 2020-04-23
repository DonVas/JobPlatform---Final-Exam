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
        private readonly IFileService fileService;
        private readonly ICompanyService companyService;
        private readonly UserManager<ApplicationUser> userManager;

        public CompaniesController(
            IFileService fileService,
            ICompanyService companyService,
            UserManager<ApplicationUser> userManager)
        {
            this.fileService = fileService;
            this.companyService = companyService;
            this.userManager = userManager;
        }

        public IActionResult UploadFile(IFormFile pictureFile)
        {
            return this.Ok();
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
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany(CompanyCreateViewModel input)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var img = await this.fileService.UploadImageFileAsync(input.PictureFile, user.Id, "CompanyLogo");

            int result = this.companyService.AddCompany(
                input.CompanyName,
                input.SanitizedCompanyDescription,
                input?.CompanyWebsite,
                input?.FacebookWebsite,
                input?.TwitterWebsite,
                input?.LinkedInWebsite,
                img?.SecureUri.ToString(),
                user.Id).Result;

            if (result < 0)
            {
                return this.View(input);
            }

            return this.RedirectToAction("Index");
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
