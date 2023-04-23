using CoreLayer.Configuration;
using CoreLayer.DTOs;
using CoreLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Service
{
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp user);
        ClientTokenDto CreateTokenByClient(Client client);
    }
}
