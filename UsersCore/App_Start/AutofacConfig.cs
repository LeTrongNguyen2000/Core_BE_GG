using UserCore.Interfaces;
using UserCore.Services;

namespace UserCore.App_Start
{
    /// <summary>
    /// AutofacConfig
    /// </summary>
    public class AutofacConfig
    {
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="services"></param>
        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddScoped<IVaiTroServices, VaiTroServices>();
            services.AddScoped<IDonViServices, DonViServices>();
            services.AddScoped<IPhongBanServices, PhongBanServices>();
            services.AddScoped<IQuyenServices, QuyenServices>();
            services.AddScoped<INguoiDungService, NguoiDungServices>();
            services.AddScoped<INguoiDungService, NguoiDungServices>();
        }
    }
}
