    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using SharedLibrayLayer.Configuration;
    using SharedLibrayLayer.Service;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace SharedLibrayLayer.Extensions
    {
        public static class CustomTokenAuth
        {
            public static void AddCustomTokenAuth(this IServiceCollection services,CustomTokenOption tokenOption,IConfiguration configuration)
            {
                services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opts =>
                {
                    var tokenOptions = configuration.GetSection("TokenOption").Get<CustomTokenOption>();
                    opts.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidIssuer = tokenOptions!.Issuer,
                        ValidAudience = tokenOptions.Audience[0],
                        IssuerSigningKey = SignService.GetSymmetricSecurityKey(tokenOptions.Issuer),
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ClockSkew = TimeSpan.Zero,
                };
                });
            }

        }
    }
