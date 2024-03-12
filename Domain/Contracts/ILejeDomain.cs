using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Domain.Contracts
{
    public interface ILejeDomain
    {
        IList<LejeDTOwithUser> getAllLeje();
    }
}
