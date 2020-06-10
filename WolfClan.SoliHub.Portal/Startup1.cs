using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WolfClan.SoliHub.Portal.Startup1))]

namespace WolfClan.SoliHub.Portal
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            //app.UseSignalR(options =>
            //{
            //    options.MapHub<GapitaHub>("/hub/GapitaHub");
            //});
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
