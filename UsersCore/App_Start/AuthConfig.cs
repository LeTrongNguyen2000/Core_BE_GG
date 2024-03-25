using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace UsersCore.App_Start
{
    public class AuthConfig
    {
        public static void Register(IConfiguration configuration, IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                options.Audience = configuration["AuthServer:ClientId"];
                options.TokenValidationParameters.ValidateAudience = false;
                options.TokenValidationParameters.ValidateIssuer = false;
            });
        }
    }
}
