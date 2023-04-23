using CoreLayer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SharedLibrayLayer.DTOs;

namespace FormManagentProject.Filters
{
    public class NotFoundFilter<TEntity,TDto>:IAsyncActionFilter where TEntity : class where TDto:class
    {
        private readonly IGenericService<TEntity, TDto> genericService;

        public NotFoundFilter(IGenericService<TEntity, TDto> genericService)
        {
            this.genericService = genericService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValues = context.ActionArguments.Values.FirstOrDefault();

            if (idValues == null)
            {
                await next.Invoke();
                return;
            }
            var id = (int)idValues;
            context.Result = new NotFoundObjectResult(CustomResponseDto<NoDataDto>.Fail(404,$"{id} not found"));
        }
    }
}
