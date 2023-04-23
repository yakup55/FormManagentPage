using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrayLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrayLayer
{
    public static class AddCustomValidationResponse
    {
        public static void UserCustomValidationResponse(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values
                    .Where(x => x.Errors.Count > 0)
                    .SelectMany(x=>x.Errors)
                    .Select(x=>x.ErrorMessage);
                    ErrorDto dto = new ErrorDto(errors.ToList());
                    var response = CustomResponseDto<NoContentResult>.Fail(400,dto);                    
                    return new BadRequestObjectResult(response);
                };
            });
        }
    }
}
