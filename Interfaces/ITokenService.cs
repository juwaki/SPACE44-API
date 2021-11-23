using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Entities;

namespace CRUD.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}