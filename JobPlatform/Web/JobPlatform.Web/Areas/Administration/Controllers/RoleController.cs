using JobPlatform.Services.Data.Interfaces;

namespace JobPlatform.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using JobPlatform.Services.Data;
    using JobPlatform.Web.ViewModels.Roles;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRolesService rolesService;

        public RoleController(
            IRolesService rolesService)
        {
            this.rolesService = rolesService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post(RoleViewModel input)
        {
            await this.rolesService.ChangeRoleAsync(input.UserId, input.RoleId, input.OnOff);
            return this.Ok("Success");
        }
    }
}
