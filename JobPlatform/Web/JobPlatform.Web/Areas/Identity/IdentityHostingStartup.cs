using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(JobPlatform.Web.Areas.Identity.IdentityHostingStartup))]

namespace JobPlatform.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
