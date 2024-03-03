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
    public interface IPushimetZyrtareDomain
    {
        IList<PushimeDTO> getAllPushime();
        PushimeDTO AddPushim(PushimePostDTO pushim);
        PushimeDTO PutPushim(Guid PushimId, PushimePostDTO pushim);
        void DeletePushim(Guid PushimId);
        PushimeDTO GetPushimById(Guid PushimId);
    }
}
