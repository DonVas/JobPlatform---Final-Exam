using System.Collections.Generic;
using JobPlatform.Web.ViewModels.Jobs;
using Microsoft.AspNetCore.Mvc;

namespace JobPlatform.Web.Controllers
{
    public class JobsController : BaseController
    {
        public IActionResult Jobs()
        {
            var viewModel = new JobViewModel();

            return this.View(viewModel);
        }

        public IActionResult Job()
        {
            var viewModel = new List<JobViewModel>();

            return this.View(viewModel);
        }
    }
}
