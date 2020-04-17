namespace JobPlatform.Web.ViewModels.Administration.Dashboard
{

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class RoleViewModel : IMapFrom<ApplicationRole>
    {
        public RoleViewModel(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
