using EAP_C2111L_NguyenTrongDuc.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EAP_C2111L_NguyenTrongDuc.Startup))]
namespace EAP_C2111L_NguyenTrongDuc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            using (var context = new ApplicationDbContext())
            {
                context.Database.Initialize(false);
                context.InitializeData();
            }

        }
    }
}
