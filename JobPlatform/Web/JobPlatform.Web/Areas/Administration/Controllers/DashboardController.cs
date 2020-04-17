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

        public async Task<IActionResult> Dashboard()
        {
            var viewModel = new UsersViewModel();

            viewModel.Users = await this.userService.GetAllUsersAsync();
            viewModel.Roles = this.userService.GetAllRoles<RoleViewModel>();

            return this.View(viewModel);
        }
    }
}
