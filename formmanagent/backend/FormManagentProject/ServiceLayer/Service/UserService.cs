using CoreLayer.DTOs;
using CoreLayer.Model;
using CoreLayer.Repository;
using CoreLayer.Service;
using CoreLayer.UnitOfWork;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using RepositoryLayer;
using ServiceLayer.Mapper;
using SharedLibrayLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceLayer.Service
{
    public class UserService:GenericService<UserApp,UserApp>,IUserService
    {
        private readonly UserManager<UserApp> userManager;
        private readonly SignInManager<UserApp> signInManager;

        public UserService(IUnitOfWork unitOfWork, IGenericRepository<UserApp> genericRepository, UserManager<UserApp> userManager, SignInManager<UserApp> signInManager) : base(unitOfWork, genericRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto login)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomResponseDto<UserApp>> CreateUserAsync(UserCreateDto createDto)
        {
            var user = new UserApp()
            {
                Email = createDto.Email,
                UserName = createDto.UserName,
                FirstName = createDto.FirstName,
                LastName = createDto.LastName,
                Age = createDto.Age,
            };
            var result=await userManager.CreateAsync(user,createDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return CustomResponseDto<UserApp>.Fail(400,new ErrorDto(errors));
            }
            return CustomResponseDto<UserApp>.Success(200,ObjectMapper.mapper.Map<UserApp>(user));
        }

        public async Task<CustomResponseDto<NoDataDto>> DeleteUser(string id)
        {
           var user=await userManager.FindByIdAsync(id);
            if (user == null)
            {
                return CustomResponseDto<NoDataDto>.Fail(404, "Id Not Found");
            }
            await userManager.DeleteAsync(user);
            return CustomResponseDto<NoDataDto>.Success(200);
        }

        public async Task<CustomResponseDto<UserApp>> GetByEmailAsync(string userMail)
        {
            var user = await userManager.FindByNameAsync(userMail);
            if (user == null)
            {
                return CustomResponseDto<UserApp>.Fail(404, "User Not Found");
            }
            return CustomResponseDto<UserApp>.Success(200,ObjectMapper.mapper.Map<UserApp>(user));
        }

        public async Task<CustomResponseDto<UserApp>> GetByUserAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return CustomResponseDto<UserApp>.Fail(404, "User Not Found");
            }
            return CustomResponseDto<UserApp>.Success(200, ObjectMapper.mapper.Map<UserApp>(user));
        }
    }
}
