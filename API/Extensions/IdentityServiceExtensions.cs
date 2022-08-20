using System;
using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config){
            // var builder = services.AddIdentityCore<AppUser>();  

            // var builder = services.AddIdentity<AppUser, IdentityRole>().AddRoles<IdentityRole>().AddDefaultTokenProviders();
            var builder = services.AddIdentityCore<AppUser>().AddRoles<IdentityRole>().AddDefaultTokenProviders();

            builder = new IdentityBuilder(builder.UserType, builder.RoleType, builder.Services);

            builder.AddEntityFrameworkStores<AppIdentityDbContext>();

            builder.AddSignInManager<SignInManager<AppUser>>();
            builder.AddUserManager<UserManager<AppUser>>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>{
                    options.TokenValidationParameters = new TokenValidationParameters{
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                        ValidIssuer = config["Token:Issuer"],
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });

            
            return services;
        }
        
    }
}
