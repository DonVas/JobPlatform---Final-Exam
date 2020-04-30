using System.Linq;
using JobPlatform.Web.ViewModels.Candidates;
using JobPlatform.Web.ViewModels.Companies;

namespace JobPlatform.Web.Areas.User.Controllers
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

    [Authorize(Roles = GlobalConstants.UserRole)]
    [Area("User")]
    public class JobsController : BaseController
    {
        private readonly IJobService jobService;
        private readonly ICompanyService companyService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICandidateService candidateService;

        public JobsController(
            IJobService jobService,
            ICompanyService companyService,
            UserManager<ApplicationUser> userManager,
            ICandidateService candidateService)
        {
            this.jobService = jobService;
            this.companyService = companyService;
            this.userManager = userManager;
            this.candidateService = candidateService;
        }

        public IActionResult Index()
        {
            var viewModel = this.jobService.GetAllJobs<JobSimpleViewModel>();
            return this.View(viewModel);
        }

        public IActionResult JobsByCompany(string id)
        {
            var viewModel = this.companyService.CompanyById<CompanyByIdViewModel>(id);
            return this.View(viewModel);
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.jobService.GetJobById<JobDetailsViewModel>(id);

            return this.View(viewModel);
        }

        public async Task<IActionResult> ApplyToJob(string id)
        {
            var user = await this.userManager.GetUserAsync(this.User);

            var viewModel = new CandidateApplyInputModel() { UserAddress = user.Address, UserId = user.Id, UserEmail = user.Email, JobId = id};
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ApplyToJobAsync(CandidateApplyInputModel input)
        {
            var viewModel = await this.jobService.AddCandidate(input.JobId, input.UserId, input.Cv, input.MotivationLetter);

            return this.RedirectToAction("Index");
        }

        public IActionResult MyApplications()
        {
            var userId = this.userManager.GetUserId(this.User);
            var viewModel = this.jobService
                .GetAllJobs<MyApplicationViewModel>()
                .Where(x =>
                    x.Candidates
                        .FirstOrDefault(c =>
                            c.CandidateId == userId) != null);

            return this.View(viewModel);
        }
    }
}
