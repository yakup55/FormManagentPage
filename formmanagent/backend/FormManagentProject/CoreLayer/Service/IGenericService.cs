using SharedLibrayLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service
{
    public interface IGenericService<TEntity,TDto> where TEntity : class where TDto : class
    {
        Task<CustomResponseDto<TDto>> GetByIdAsync(int id);
        Task<CustomResponseDto<IEnumerable<TDto>>> GetAllAsync();
        Task<CustomResponseDto<TDto>> AddAsync(TDto entity);
        Task<CustomResponseDto<NoDataDto>> UpdateAsync(TDto entity, int id);
        Task<CustomResponseDto<NoDataDto>> DeleteAsync(int id);
        Task<CustomResponseDto<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
