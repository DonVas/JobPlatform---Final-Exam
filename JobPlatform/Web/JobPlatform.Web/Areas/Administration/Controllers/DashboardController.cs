using JobPlatform.Services.Data.Interfaces;

namespace JobPlatform.Web.Areas.Administration.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IUserService userService;

        public DashboardController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Dashboard()
        {
            return this.View();
        }

        public IActionResult Settings()
        {
            return this.View();
        }
    }
}
