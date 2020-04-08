namespace JobPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRolesService
    {
        Task ChangeRoleAsync(string userId, string roleId, bool onOff);
    }
}
