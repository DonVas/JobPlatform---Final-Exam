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
        public IActionResult Index()
        {
           return this.View();
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

        public IActionResult Details()
        {
            return this.View();
        }
    }
}
