using CoreLayer.DTOs;
using CoreLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormManagentProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            return ActionResultInstance(await service.GetAllAsync());
        }
        [HttpGet("{email}")]
        public async Task<IActionResult> GetByUserEmail(string email)
        {
            return ActionResultInstance(await service.GetByEmailAsync(email));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByUser(string id)
        {
            return ActionResultInstance(await service.GetByUserAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateDto user)
        {
            return ActionResultInstance(await service.CreateUserAsync(user));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            return ActionResultInstance(await service.DeleteUser(id));
        }
    }
}
