using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
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
    public class AftesiDomain : DomainBase, IAftesiDomain
    {
        public AftesiDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        private IAftesiRepository AftesiRepository => _unitOfWork.GetRepository<IAftesiRepository>();

        public AftesiDTO AddAftesi(AftesiPostDTO AftesiDTO)
        {
            var aftesiEntity = _mapper.Map<Aftesi>(AftesiDTO);
            aftesiEntity.AftesiId = Guid.NewGuid();
            var aftesiFinal = AftesiRepository.Add(aftesiEntity);
            var aftesiToReturn = _mapper.Map<AftesiDTO>(aftesiFinal);
            _unitOfWork.Save();
            return aftesiToReturn;
        }

        public void DeleteAftesi(Guid AftesiId)
        {
            try
            {
                var aftesi = AftesiRepository.GetById(AftesiId);
                if (aftesi is null)
                    throw new Exception();
                AftesiRepository.Remove(AftesiId);
                _unitOfWork.Save();

            }

            catch (Exception)
            {
                throw;
            }
        }

        public AftesiDTO GetAftesiById(Guid AftesiId)
        {
            var aftesi = AftesiRepository.GetById(AftesiId);
            return _mapper.Map<AftesiDTO>(aftesi);
        }

        public void PutAftesi(Guid AftesiId, AftesiPostDTO aftesi)
        {
            var Aftesientity = AftesiRepository.GetById(AftesiId);

            if (Aftesientity is null)
                throw new Exception();
            Aftesientity = _mapper.Map<AftesiPostDTO, Aftesi>(aftesi, Aftesientity);

            AftesiRepository.Update(Aftesientity);
            _unitOfWork.Save();
        }

        public IList<AftesiDTO> getAllAftesi()
        {
            IEnumerable<Aftesi> aftesis = AftesiRepository.GetAll();

            var result = _mapper.Map<IList<AftesiDTO>>(aftesis);
            return result;
        }
    }
}
