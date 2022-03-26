using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_1911060590_NguyenNhatATien_BigSchool.Startup))]
namespace _1911060590_NguyenNhatATien_BigSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
