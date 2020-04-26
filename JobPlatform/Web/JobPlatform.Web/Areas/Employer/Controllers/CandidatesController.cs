using JobPlatform.Data.Common.Repositories;
using JobPlatform.Data.Models;
using JobPlatform.Services.Data.Interfaces;
using JobPlatform.Web.ViewModels.Candidates;

namespace JobPlatform.Web.Areas.Employer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobPlatform.Common;
    using JobPlatform.Web.Controllers;
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

        public IActionResult GetById(string id)
        {
            return this.View();
        }

        public IActionResult EditCandidate()
        {
            return this.View();
        }

        public IActionResult DeleteCandidate()
        {
            return this.View();
        }

        public IActionResult Details(string id)
        {
            var viewModel = this.candidateService.GetCandidateByUserId<CandidateDetailsViewModel>(id);

            return this.View(viewModel);
        }
    }
}
