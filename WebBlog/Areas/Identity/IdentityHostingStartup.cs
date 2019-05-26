using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(WebBlog.Areas.Identity.IdentityHostingStartup))]
namespace WebBlog.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}