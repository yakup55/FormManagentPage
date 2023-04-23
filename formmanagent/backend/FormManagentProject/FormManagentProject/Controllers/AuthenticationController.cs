using CoreLayer.DTOs;
using CoreLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormManagentProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService service;

        public AuthenticationController(IAuthenticationService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto login)
        {
            return ActionResultInstance(await service.CreateTokenAsync(login));
        }
    }
}
