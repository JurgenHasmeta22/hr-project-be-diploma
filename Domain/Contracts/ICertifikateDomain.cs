using DTO.CertifikateDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public  interface ICertifikateDomain
    {
        CertifikateDTO AddCertifikate(CertifikatePostDTO certifikate);
        IList<CertifikateDTO1> getAllCertifikate();
        CertifikateDTO GetCertifikateById(Guid CertId);

        void PutCertifikate(Guid CertId, CertifikatePostDTO certifikate);
        void DeleteCertifikate(Guid CertId);
        
    }
}
