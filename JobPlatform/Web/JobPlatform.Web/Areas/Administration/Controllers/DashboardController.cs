namespace JobPlatform.Web.Areas.Administration.Controllers
{
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data;
    using JobPlatform.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IUserService userService;

        public DashboardController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Index()
        {
            var viewModel = new UsersViewModel();

            viewModel.Users = this.userService.GetAllUsers();
            viewModel.Roles = this.userService.GetAllRoles<RolesViewModel>();

            return this.View(viewModel);
        }
    }
}
