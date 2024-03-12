using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Domain.Contracts
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
