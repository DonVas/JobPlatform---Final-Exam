using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using JobPlatform.Data.Models;
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

        public CandidatesController(
            ICandidateService candidateService,
            ICompanyService companyService,
            UserManager<ApplicationUser> userManager)
        {
            this.candidateService = candidateService;
            this.companyService = companyService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var companyId = this.companyService.CompanyByUserId(user.Id.ToString());
            if (companyId == null)
            {
                return this.View();
            }

            var viewModel = this.candidateService
                .GetAllCandidatesByCompanyId<CandidateSimpleViewModel>(companyId.Id);
            return this.View(viewModel);
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.candidateService.GetCandidateByUserId<CandidateDetailsViewModel>(id);

            return this.View(viewModel);
        }
    }
}
