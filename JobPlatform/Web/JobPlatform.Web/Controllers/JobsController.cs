namespace JobPlatform.Web.Controllers
{
    using System.Threading.Tasks;

    using JobPlatform.Common;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Web.ViewModels.Companies;
    using JobPlatform.Web.ViewModels.Jobs;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator, Moderator")]
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

        public IActionResult Index()
        {
            var viewModel = this.jobService.GetAllJobs<JobSimpleViewModel>();
            return this.View(viewModel);
        }

        public IActionResult DeleteJob(string id)
        {
            var viewModel = this.jobService.GetJobById<DeletedJobViewModel>(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteJobConfirm(string id)
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
