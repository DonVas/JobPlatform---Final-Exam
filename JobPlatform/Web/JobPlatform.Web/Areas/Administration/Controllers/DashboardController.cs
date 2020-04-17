namespace JobPlatform.Web.Areas.Administration.Controllers
{
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data;
    using JobPlatform.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

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
