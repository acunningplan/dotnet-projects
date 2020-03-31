using Burgler.Entities;
using Burgler.Entities.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Burgler.BusinessLogic.JwtServices
{
    public interface IJwtServices
    {
        string CreateToken(AppUser user);
    }
}
