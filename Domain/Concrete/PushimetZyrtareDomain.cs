using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

namespace Domain.Concrete
{
    public class PushimetZyrtareDomain : DomainBase, IPushimetZyrtareDomain
    {
        public PushimetZyrtareDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, httpContextAccessor) { }

        private IPushimetZyrtareRepository pushimetRepository =>
            _unitOfWork.GetRepository<IPushimetZyrtareRepository>();

        public PushimeDTO AddPushim(PushimePostDTO pushim)
        {
            var pushimEntity = _mapper.Map<PushimetZyrtare>(pushim);
            pushimEntity.PushimId = Guid.NewGuid();

            var pushimfinal = pushimetRepository.Add(pushimEntity);
            _unitOfWork.Save();
            return _mapper.Map<PushimeDTO>(pushimfinal);
        }

        public IList<PushimeDTO> getAllPushime()
        {
            var pushimet = pushimetRepository.GetAll();
            return _mapper.Map<IList<PushimeDTO>>(pushimet);
        }

        public PushimeDTO PutPushim(Guid PushimId, PushimePostDTO pushim)
        {
            var pushimentity = pushimetRepository.GetById(PushimId);

            if (pushimentity is null)
                throw new Exception();
            pushimentity = _mapper.Map<PushimePostDTO, PushimetZyrtare>(pushim, pushimentity);

            pushimetRepository.Update(pushimentity);
            _unitOfWork.Save();
            return _mapper.Map<PushimeDTO>(pushimentity);
        }

        public void DeletePushim(Guid PushimId)
        {
            if (pushimetRepository.GetById(PushimId) == null)
                throw new Exception();
            pushimetRepository.Remove(PushimId);
            _unitOfWork.Save();
        }

        public PushimeDTO GetPushimById(Guid PushimId)
        {
            if (pushimetRepository.GetById(PushimId) == null)
                throw new Exception();
            var pushimentity = pushimetRepository.GetById(PushimId);
            return _mapper.Map<PushimeDTO>(pushimentity);
        }
    }
}
