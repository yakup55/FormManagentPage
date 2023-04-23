using CoreLayer.DTOs;
using CoreLayer.Model;
using CoreLayer.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormManagentProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FormController : BaseController
    {
        private readonly IFormService service;

        public FormController(IFormService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllForm()
        {
            return ActionResultInstance(await service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult>GetByForm(int id)
        {
            return ActionResultInstance(await service.GetByIdAsync(id));
        }
        [HttpGet("{search}")]
        public async Task<IActionResult>SearchForm(string search)
        {
            return ActionResultInstance(await service.SearachForm(search));
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> FormUser(string userId)
        {
            return ActionResultInstance(await service.FormUser(userId));
        }
        [HttpPost]
        public async Task<IActionResult>AddForm(FormDto form)
        {
            form.FormCreateAt= DateTime.Now;
            return ActionResultInstance(await service.AddAsync(form));
        }
        [HttpPut]
        public async Task<IActionResult>UpdateForm(FormDto form)
        {
            return ActionResultInstance(await service.UpdateAsync(form,form.FormId));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForm(int id) 
        {
            return ActionResultInstance(await service.DeleteAsync(id));
        }
    }
}
