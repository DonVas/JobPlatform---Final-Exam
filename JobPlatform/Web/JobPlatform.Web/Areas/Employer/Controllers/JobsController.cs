using JobPlatform.Common;
using JobPlatform.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobPlatform.Web.Areas.Employer.Controllers
{
    [Authorize(Roles = GlobalConstants.Employer)]
    [Area("Employer")]
    public class JobsController : BaseController
    {

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult JobById(string id)
        {
            return this.View();
        }

        public IActionResult AddJob()
        {
            return this.View();
        }

        public IActionResult DeleteJob()
        {
            return this.View();
        }

        public IActionResult EditJob()
        {
            return this.View();
        }

        public IActionResult Details()
        {
            return this.View();
        }
    }
}
