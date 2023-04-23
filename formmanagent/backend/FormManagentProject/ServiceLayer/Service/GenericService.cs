using CoreLayer.Repository;
using CoreLayer.Service;
using CoreLayer.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Mapper;
using SharedLibrayLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<TEntity> genericRepository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> genericRepository)
        {
            this.unitOfWork = unitOfWork;
            this.genericRepository = genericRepository;
        }

        public async Task<CustomResponseDto<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.mapper.Map<TEntity>(entity);
            await genericRepository.AddAsync(newEntity);
            await unitOfWork.CommintAsync();
            var newDto = ObjectMapper.mapper.Map<TDto>(entity);
            return CustomResponseDto<TDto>.Success(200, newDto);


        }

        public async Task<CustomResponseDto<NoDataDto>> DeleteAsync(int id)
        {
            var isExistEntity = await genericRepository.GetByIdAsync(id);
            if (isExistEntity == null)
            {
                return CustomResponseDto<NoDataDto>.Fail(404, "Id Not Found");
            }
            genericRepository.DeleteAsync(isExistEntity);
            await unitOfWork.CommintAsync();
            return CustomResponseDto<NoDataDto>.Success(204);
        }

        public async Task<CustomResponseDto<IEnumerable<TDto>>> GetAllAsync()
        {
            var all = ObjectMapper.mapper.Map<List<TDto>>(await genericRepository.GetAllAsync());
            return CustomResponseDto<IEnumerable<TDto>>.Success(200, all);
        }

        public async Task<CustomResponseDto<TDto>> GetByIdAsync(int id)
        {
            var one = await genericRepository.GetByIdAsync(id);
            if (one == null)
            {
                return CustomResponseDto<TDto>.Fail(404, "Id Not Found");
            }
            return CustomResponseDto<TDto>.Success(200, ObjectMapper.mapper.Map<TDto>(one));
        }

        public Task<CustomResponseDto<NoDataDto>> UpdateAsync(TDto entity, int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list = genericRepository.Where(predicate);
            return CustomResponseDto<IEnumerable<TDto>>.Success(200, ObjectMapper.mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()));
        }
    }
}