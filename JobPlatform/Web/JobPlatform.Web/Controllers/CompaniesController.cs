using Microsoft.AspNetCore.Http;

namespace JobPlatform.Web.Controllers
{
    using System.Threading.Tasks;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Web.ViewModels.Companies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator, Moderator")]
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

        public IActionResult Details(string id)
        {
            var viewModel = this.companyService.CompanyById<CompanyDetailsViewModel>(id);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Company(string id)
        {
            var viewModel = this.companyService.CompanyById<CompanyViewModel>(id);

            return this.View(viewModel);
        }

        public IActionResult Delete(string id)
        {
            var viewModel = this.companyService.CompanyById<CompanySimpleViewModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult DeleteCompany(string id)
        {
            var result = this.companyService.DeleteById(id).Result;

            if (!result)
            {
                return this.NotFound();
            }

            return this.RedirectToAction("Index");
        }

        public IActionResult EditCompany(string id)
        {
            var viewModel = this.companyService.CompanyById<CompanyEditViewModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCompany(CompanyEditViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            int result = this.companyService.EditCompany(
                input.CompanyName,
                input.SanitizedCompanyDescription,
                input?.CompanyWebsite,
                input?.FacebookWebsite,
                input?.TwitterWebsite,
                input?.LinkedInWebsite,
                null,
                input.Id).Result;

            return this.RedirectToAction("Details");
        }
    }
}
