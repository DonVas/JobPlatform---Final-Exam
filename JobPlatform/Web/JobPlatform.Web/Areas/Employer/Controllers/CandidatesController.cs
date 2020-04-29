using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JobPlatform.Data.Models;
using JobPlatform.Web.ViewModels.Jobs;
using Microsoft.AspNetCore.Identity;

namespace JobPlatform.Web.Areas.Employer.Controllers
{
    using JobPlatform.Common;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Web.Controllers;
    using JobPlatform.Web.ViewModels.Candidates;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.Employer)]
    [Area("Employer")]
    public class CandidatesController : BaseController
    {
        private readonly ICandidateService candidateService;
        private readonly ICompanyService companyService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJobService jobService;

        public CandidatesController(
            ICandidateService candidateService,
            ICompanyService companyService,
            UserManager<ApplicationUser> userManager,
            IJobService jobService)
        {
            this.candidateService = candidateService;
            this.companyService = companyService;
            this.userManager = userManager;
            this.jobService = jobService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var companyId = this.companyService.CompanyByUserId(user.Id.ToString());
            if (companyId == null)
            {
                return this.View();
            }

            var viewModel = this.jobService
                    .GetAllJobsByCompanyId<MyCandidatesViewModel>(companyId.Id);

            return this.View(viewModel);
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.candidateService.GetCandidateByUserId<CandidateDetailsViewModel>(id);

            return this.View(viewModel);
        }
    }
}
