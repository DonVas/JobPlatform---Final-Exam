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

        // POST /api/role
        // Request body: {"userId":05213546-e4f8-4632-9ab9-45a4f79123b0,"roleId":632f31bc-0b95-405e-8188-eb0e52e73705, "OnOff":true}
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post(RoleViewModel input)
        {
            await this.rolesService.ChangeRoleAsync(input.UserId, input.RoleId, input.OnOff);
            return this.Ok("Success");
        }
    }
}
