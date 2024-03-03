using DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Domain.Contracts
{
    public interface ILejeDomain 
    {
        

        IList<LejeDTOwithUser> getAllLeje();

        
    }
}
