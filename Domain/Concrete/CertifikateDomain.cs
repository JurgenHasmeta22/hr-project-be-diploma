using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.CertifikateDTO;
using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public  class CertifikateDomain : DomainBase, ICertifikateDomain
    {
        public CertifikateDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        private ICertifikateRepository  certifikateRepository => _unitOfWork.GetRepository<ICertifikateRepository>();

        public CertifikateDTO AddCertifikate(CertifikatePostDTO certifikate)
        {
            var CertifikateEntity = _mapper.Map<Certifikate>(certifikate);
            CertifikateEntity.CertId = Guid.NewGuid();
            var CertifikateFinal = certifikateRepository.Add(CertifikateEntity);
            var certifikateToReturn = _mapper.Map<CertifikateDTO>(CertifikateFinal);
            _unitOfWork.Save();
            return certifikateToReturn;
        }

        public void DeleteCertifikate(Guid CertId)
        {
            try
            {
                var certifikate = certifikateRepository.GetById(CertId);
                if (certifikate is null)
                    throw new Exception();
                certifikateRepository.Remove(CertId);
                _unitOfWork.Save();

            }

            catch (Exception )
            {
                throw ;
            }
        }
    

       

       

        public CertifikateDTO GetCertifikateById(Guid CertId)
        {
            var certifikates = certifikateRepository.GetById(CertId);
            return _mapper.Map<CertifikateDTO>(certifikates);
        }

       

        public void PutCertifikate(Guid CertId, CertifikatePostDTO certifikate)
        {
            var certifikateEntity = certifikateRepository.GetById(CertId);

            if (certifikateEntity is null)
                throw new Exception();
            certifikateEntity = _mapper.Map<CertifikatePostDTO, Certifikate>(certifikate, certifikateEntity);

            certifikateRepository.Update(certifikateEntity);
            _unitOfWork.Save();
        }

        public  IList<CertifikateDTO1> getAllCertifikate()
        {
            IEnumerable<Certifikate> certifikates = certifikateRepository.GetAll();

            
            var result =_mapper.Map<IList<CertifikateDTO1>>(certifikates);

            return result;
        }

       
    }
}
