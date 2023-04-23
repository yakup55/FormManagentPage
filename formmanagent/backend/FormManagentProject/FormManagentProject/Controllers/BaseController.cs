using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedLibrayLayer.DTOs;

namespace FormManagentProject.Controllers
{
    
    public class BaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(CustomResponseDto<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
