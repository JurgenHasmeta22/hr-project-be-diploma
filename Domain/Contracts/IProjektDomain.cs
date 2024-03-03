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
    public interface IProjektDomain
    {
         ProjektDTO AddProject(ProjektPostDTO projekt);
         
         IList<Projekt1DTO> getAllProjects();

         ProjektDTO GetProjectById(Guid ProjektId); 

         void PutProject(Guid ProjektId,ProjektPostDTO projekt);

         void DeleteProject(Guid ProjektId);

          void PatchProject(Guid ProjektId,JsonPatchDocument patchDoc);
        
    }
}
