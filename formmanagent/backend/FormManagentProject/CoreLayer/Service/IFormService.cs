using CoreLayer.DTOs;
using CoreLayer.Model;
using SharedLibrayLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service
{
    public interface IFormService:IGenericService<Form,FormDto>
    {
        Task<CustomResponseDto<List<Form>>> FormUser(string userId);
        Task<CustomResponseDto<List<Form>>> SearachForm(string form);
    }
}
