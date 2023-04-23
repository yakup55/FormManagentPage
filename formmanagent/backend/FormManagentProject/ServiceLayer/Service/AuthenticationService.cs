using Azure;
using CoreLayer.Configuration;
using CoreLayer.DTOs;
using CoreLayer.Model;
using CoreLayer.Repository;
using CoreLayer.Service;
using CoreLayer.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SharedLibrayLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly List<Client> clients;
        private readonly UserManager<UserApp> userManager;
        private readonly SignInManager<UserApp> signInManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> genericService;
        private readonly ITokenService tokenService;

        public AuthenticationService(IOptions<List<Client>> clients, UserManager<UserApp> userManager, IUnitOfWork unitOfWork, IGenericRepository<UserRefreshToken> genericService, SignInManager<UserApp> signInManager, ITokenService tokenService)
        {
            this.clients = clients.Value;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.genericService = genericService;
            this.signInManager = signInManager;
            this.tokenService = tokenService;
        }
        public async Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto login)
        {
            if (login == null)
            {
                throw new ArgumentNullException(nameof(login));
            }
            var user = await userManager.FindByNameAsync(login.UserName);
            if (user == null)
            {
                user.Status = false;
                return CustomResponseDto<TokenDto>.Fail(400, "Kullanıcı Yok");
            }
            var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, true);
           
            if (!result.Succeeded)
            {
                user.Status = false;
                return CustomResponseDto<TokenDto>.Fail(400,$"Başarısız giriş sayısı={await userManager.GetAccessFailedCountAsync(user)}");

            }
            user.Status = true;
            var token = tokenService.CreateToken(user);
            var userRefreshToken = await genericService.Where(x => x.userId == user.Id).SingleOrDefaultAsync();
            if (userRefreshToken == null)
            {
                await genericService.AddAsync(new UserRefreshToken()
                {
                    userId = user.Id,
                    Code = token.RefreshToken,
                    Expiration = token.RefreshTokenExpiration
                });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }
            await unitOfWork.CommintAsync();

            return CustomResponseDto<TokenDto>.Success(200,token);
        }

      


        public async Task<CustomResponseDto<NoDataDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefresToken = await genericService.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefresToken is null)
            {
                return CustomResponseDto<NoDataDto>.Fail(404, "RefreshToken Not Found");
            }
            genericService.DeleteAsync(existRefresToken);
            return CustomResponseDto<NoDataDto>.Success(200);
        }


        public async Task<CustomResponseDto<NoDataDto>> LogOut(string id)
        {
            var hasUser = await userManager.FindByIdAsync(id);
            hasUser.Status = false;
            await userManager.UpdateAsync(hasUser);
            await signInManager.SignOutAsync();
            return CustomResponseDto<NoDataDto>.Success(200);
        }

        public Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public CustomResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            throw new NotImplementedException();
        }
    }
}
