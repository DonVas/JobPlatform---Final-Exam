using JobPlatform.Web.ViewModels.Companies;

namespace JobPlatform.Web.Areas.Employer.Controllers
{
    using System.Threading.Tasks;

    using JobPlatform.Common;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Web.Controllers;
    using JobPlatform.Web.ViewModels.Jobs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.Employer)]
    [Area("Employer")]
    public class JobsController : BaseController
    {
        private readonly IJobService jobService;
        private readonly ICompanyService companyService;
        private readonly UserManager<ApplicationUser> userManager;

        public JobsController(
            IJobService jobService,
            ICompanyService companyService,
            UserManager<ApplicationUser> userManager)
        {
            this.jobService = jobService;
            this.companyService = companyService;
            this.userManager = userManager;
        }

        public IActionResult Index(string id)
        {
            var user = this.userManager.GetUserId(this.User);
            CompanyByIdViewModel viewModel = null;
            if (id == null)
            {
                id = this.companyService.CompanyByUserId(user.ToString())?.UserId;
                if (id == null)
                {
                    return this.View();
                }

                viewModel = this.companyService.CompanyByUserId<CompanyByIdViewModel>(id);
            }
            else
            {
                viewModel = this.companyService.CompanyById<CompanyByIdViewModel>(id);
            }

            return this.View(viewModel);
        }

        public IActionResult JobById(string id)
        {
            return this.View();
        }

        public IActionResult AddJob()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddJob(AddJobViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);

            var company = this.companyService.CompanyByUserId(user.Id.ToString());

            await this.jobService.AddJob(
                company.Id,
                input.CompanyEmail,
                input.JobTitle,
                input.JobCategory,
                input.LocationCity,
                input.JobType,
                input.Description);

            return this.RedirectToAction("Index");
        }

        public IActionResult DeleteJob(string id)
        {
            var viewModel = this.jobService.GetJobById<DeletedJobViewModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteJobConfirmAsync(string id)
        {
            await this.jobService.DeleteJobById(id);
            return this.RedirectToAction("Index");
        }

        public IActionResult EditJob(string id)
        {
            var viewModel = this.jobService.GetJobById<EditJobViewModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditJob(EditJobViewModel input)
        {
            await this.jobService.EditJob(
                input.Id,
                input.CompanyEmail,
                input.JobTitle,
                input.JobCategory,
                input.LocationCity,
                input.JobType,
                input.Description);

            return this.RedirectToAction("Index");
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.jobService.GetJobById<JobDetailsViewModel>(id);

            return this.View(viewModel);
        }
    }
}
