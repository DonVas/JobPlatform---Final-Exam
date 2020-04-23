namespace JobPlatform.Web.Controllers
{
    using System.Collections.Generic;

    using JobPlatform.Web.ViewModels.Jobs;
    using Microsoft.AspNetCore.Mvc;

    public class JobsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Job()
        {
            var viewModel = new List<JobViewModel>();

            return this.View();
        }
    }
}
