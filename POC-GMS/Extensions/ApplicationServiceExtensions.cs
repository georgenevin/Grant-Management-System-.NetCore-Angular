using business.Implementation;
using business.Interfaces;
using data.Data;
using data.Implementation;
using data.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog.Core;
using Serilog;

namespace POC_GMS.Extensions
{
    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {



            services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnnectionString"))
            );

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {


                option.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                    ValidateIssuer = false,
                    ValidateAudience=false,

                };


            });


            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUser, User>();
            services.AddTransient<IGrant, Grant>();
            services.AddTransient<IGrantRepository, GrantRepository>();
            services.AddTransient<IApplicant, Applicant>();
            services.AddTransient<IApplicantRepository, ApplicantRepository>();
            services.AddTransient<IReview, Review>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddSingleton<ITokenService, TokenService>();
          //  services.AddTransient<ILogger, Logger>();
            
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


            return services;
        }


    }
}
