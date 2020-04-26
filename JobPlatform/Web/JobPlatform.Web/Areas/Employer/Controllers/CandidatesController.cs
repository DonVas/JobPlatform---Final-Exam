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

        public CandidatesController(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        public IActionResult Index()
        {
            var viewModel = this.candidateService.GetAllCandidates<CandidateSimpleViewModel>();
            return this.View(viewModel);
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.candidateService.GetCandidateByUserId<CandidateDetailsViewModel>(id);

            return this.View(viewModel);
        }
    }
}
