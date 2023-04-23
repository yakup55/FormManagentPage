using CoreLayer.DTOs;
using CoreLayer.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using SharedLibrayLayer.DTOs;

namespace CoreLayer.Service
{
    public interface IUserService:IGenericService<UserApp, UserApp>
    {
        Task<CustomResponseDto<UserApp>> CreateUserAsync(UserCreateDto createDto);
        Task<CustomResponseDto<UserApp>> GetByEmailAsync(string userMail);
        Task<CustomResponseDto<UserApp>> GetByUserAsync(string userId);
        Task<CustomResponseDto<NoDataDto>> DeleteUser(string id);

    }
}
