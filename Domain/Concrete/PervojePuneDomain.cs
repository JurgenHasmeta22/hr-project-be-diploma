using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.PervojePuneDTO;
using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete {
#pragma warning disable CS0168 // Variable is declared but never used
#pragma warning disable CS8603 // Possible null reference return.

	internal class PervojePuneDomain : DomainBase, IPervojePuneDomain {
		public PervojePuneDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor) {
		}

		private IPervojPuneRepository PPRepositoryInstance => _unitOfWork.GetRepository<IPervojPuneRepository>();
		private IUserRepository userRepositoryInstance => _unitOfWork.GetRepository<IUserRepository>();

		public PervojePuneDTO AddPervojePune(PostPutPPDTO ppDTO) {
			var pervojePune = _mapper.Map<PervojePune>(ppDTO);
			pervojePune.Ppid = Guid.NewGuid();
			PPRepositoryInstance.Add(pervojePune);
			_unitOfWork.Save();
			return _mapper.Map<PervojePuneDTO>(pervojePune);
		}

		public IEnumerable<PervojePuneDTO> GetAllPervojePune() {
			var pervojePune = PPRepositoryInstance.GetAll();
			return _mapper.Map<IEnumerable<PervojePuneDTO>>(pervojePune);

		}

		public PervojePuneDTO GetPervojePune(Guid ppId) {
			var pervojePune = PPRepositoryInstance.GetById(ppId);
			if (pervojePune == null)
				throw new ArgumentException("Work experience does not exist");
			return _mapper.Map<PervojePuneDTO>(pervojePune);
		}

		public PervojePuneDTO GetPervojePune(string ppName) {
			var pervojePune = PPRepositoryInstance.GetByName(ppName);
			if (pervojePune == null)
				throw new ArgumentException("Work experience does not exist");
			return _mapper.Map<PervojePuneDTO>(pervojePune);
		}

		public void RemovePervojePune(Guid ppId) {
			var pp = PPRepositoryInstance.GetById(ppId);
			if (pp == null)
				throw new ArgumentException("Work experience does not exist");

			var mapping = pp.UserPervojePunes;
			if (mapping == null)
				throw new Exception();

			mapping.Clear();
			PPRepositoryInstance.Remove(ppId);
			_unitOfWork.Save();
		}

		public void UpdatePervojePune(Guid ppId, PostPutPPDTO ppDTO) {
			if (PPRepositoryInstance.Contains(ppId) == false)
				throw new ArgumentException("Work experience does not exist");

			var pp = PPRepositoryInstance.GetById(ppId);

			_mapper.Map(ppDTO, pp);

			PPRepositoryInstance.Update(pp);
			_unitOfWork.Save();
		}

		public void AssignPPToUser(UserPPDTO userPPDTO) {
			var entity = userRepositoryInstance.GetById(userPPDTO.UserId);
			if (entity == null)
				throw new ArgumentException("User does not exist");

			if (entity.UserIsActive == false)
				throw new ArgumentException("User is deactivated");

			if (PPRepositoryInstance.Contains(userPPDTO.Ppid) == false)
				throw new ArgumentException("Work experience does not exist");

			var userPP = _mapper.Map<UserPervojePune>(userPPDTO);

			if (entity.UserPervojePunes.Contains(userPP) == true)
				throw new ArgumentException("User already has work experience");

			entity.UserPervojePunes.Add(userPP);
			_unitOfWork.Save();
		}

		public IEnumerable<PervojePuneDTO> GetPPs(Guid userId) {
			var mapping = userRepositoryInstance.GetPPOfUser(userId);
			if (mapping == null)
				throw new ArgumentException("User does not exist");

			List<PervojePune> list = new List<PervojePune>();

			foreach (var entry in mapping)
				list.Add(entry.Pp);

			return _mapper.Map<IEnumerable<PervojePuneDTO>>(list.AsEnumerable());
		}

		public IEnumerable<UserDTO> GetUsers(Guid ppId) {
			var mapping = PPRepositoryInstance.GetUsersOfPP(ppId);
			if (mapping == null)
				throw new ArgumentException("Work experience does not exist");

			List<AppUser> list = new List<AppUser>();

			foreach (var entry in mapping) {
				if (entry.User.UserIsActive == true)
					list.Add(entry.User);
			}

			return _mapper.Map<IEnumerable<UserDTO>>(list.AsEnumerable());
		}

		public PervojePunePaginate Paginate(int page) {
			if (page == 0)
				throw new ArgumentException("Invalid page");

			var pps = PPRepositoryInstance.GetAll();

			if (pps == null)
				throw new NullReferenceException("Unable to get work experiences");

			var nrResults = 5f;
			var nrPages = Math.Ceiling(PPRepositoryInstance.GetAll().Count() / nrResults);

			if (page > nrPages)
				throw new ArgumentException("Invalid page");

			var ppList = PPRepositoryInstance.Paginate(page, (int)nrResults, (int)nrPages);

			var ppListDTO = _mapper.Map<IEnumerable<PervojePuneDTO>>(ppList);

			return new PervojePunePaginate {
				list = ppListDTO,
				currentPage = page,
				pages = (int)nrPages
			};
		}
	}
}
