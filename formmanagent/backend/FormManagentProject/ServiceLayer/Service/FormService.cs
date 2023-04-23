using CoreLayer.DTOs;
using CoreLayer.Model;
using CoreLayer.Repository;
using CoreLayer.Service;
using CoreLayer.UnitOfWork;
using SharedLibrayLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class FormService : GenericService<Form, FormDto>, IFormService
    {
        private readonly IFormRepository formRepository;

        public FormService(IUnitOfWork unitOfWork, IGenericRepository<Form> genericRepository, IFormRepository formRepository) : base(unitOfWork, genericRepository)
        {
            this.formRepository = formRepository;
        }

        public async Task<CustomResponseDto<List<Form>>> FormUser(string userId)
        {
            return CustomResponseDto<List<Form>>.Success(200,await formRepository.FormUser(userId));
        }

        public async Task<CustomResponseDto<List<Form>>> SearachForm(string form)
        {
            return  CustomResponseDto<List<Form>>.Success(200,await formRepository.SearachForm(form));
        }
    }
}
