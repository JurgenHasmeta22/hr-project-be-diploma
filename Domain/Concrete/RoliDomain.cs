using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.RoleDTO;
using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;

namespace Domain.Concrete
{
#pragma warning disable CS0168 // Variable is declared but never used
#pragma warning disable CS8603 // Possible null reference return.

    internal class RoliDomain : DomainBase, IRoliDomain
    {
        public RoliDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(unitOfWork, mapper, httpContextAccessor) { }

        private IRoliRepository roliRepositoryInstance => _unitOfWork.GetRepository<IRoliRepository>();
        private IUserRepository userRepositoryInstance => _unitOfWork.GetRepository<IUserRepository>();

        public RoleDTO AddRole(PostPutRoleDTO roleDTO)
        {
            var role = _mapper.Map<Roli>(roleDTO);
            role.RoliId = Guid.NewGuid();
            roliRepositoryInstance.Add(role);
            _unitOfWork.Save();
            return _mapper.Map<RoleDTO>(role);
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            var roles = roliRepositoryInstance.GetAll();
            return _mapper.Map<IEnumerable<RoleDTO>>(roles);
        }

        public RoleDTO GetRoleById(Guid id)
        {
            var role = roliRepositoryInstance.GetById(id);
            if (role == null)
                throw new ArgumentException("Role does not exist");
            return _mapper.Map<RoleDTO>(role);
        }

        public RoleDTO GetRoleByName(string roleName)
        {
            var role = roliRepositoryInstance.GetByName(roleName);
            if (role == null)
                throw new ArgumentException("Role does not exist");
            return _mapper.Map<RoleDTO>(role);
        }

        public void RemoveRole(Guid id)
        {
            var role = roliRepositoryInstance.GetById(id);
            if (role == null)
                throw new ArgumentException("Role does not exist");

            var mapping = role.UserRolis;
            if (mapping == null)
                throw new Exception();

            mapping.Clear();
            roliRepositoryInstance.Remove(id);
            _unitOfWork.Save();
        }

        public void UpdateRole(Guid id, PostPutRoleDTO roleDTO)
        {
            if (roliRepositoryInstance.Contains(id) == false)
                throw new ArgumentException("Role does not exist");

            var role = roliRepositoryInstance.GetById(id);

            _mapper.Map(roleDTO, role);

            roliRepositoryInstance.Update(role);
            _unitOfWork.Save();
        }

        public void AssignRoleToUser(UserRoleDTO userRoleDTO)
        {
            var entity = userRepositoryInstance.GetById(userRoleDTO.UserId);
            if (entity == null)
                throw new ArgumentException("User does not exist");

            if (entity.UserIsActive == false)
                throw new ArgumentException("User is deactivated");

            if (roliRepositoryInstance.Contains(userRoleDTO.RoliId) == false)
                throw new ArgumentException("Role does not exist");

            var userRole = _mapper.Map<UserRoli>(userRoleDTO);

            if (entity.UserRolis.Contains(userRole) == true)
                throw new ArgumentException("User already has role");

            entity.UserRolis.Add(userRole);
            _unitOfWork.Save();
        }

        public IEnumerable<UserDTO> GetUsers(Guid roleId)
        {
            var mapping = roliRepositoryInstance.GetUsersOfRole(roleId);
            if (mapping == null)
                throw new ArgumentException("Role does not exist");

            List<AppUser> list = new List<AppUser>();

            foreach (var entry in mapping)
            {
                if (entry.User.UserIsActive == true)
                    list.Add(entry.User);
            }

            return _mapper.Map<IEnumerable<UserDTO>>(list.AsEnumerable());
        }

        //public IEnumerable<RoleDTO> GetRoles(Guid userId) {

        //          var mapping = userRepositoryInstance.GetRolesOfUser(userId);
        //	if (mapping == null)
        //		throw new ArgumentException("User does not exist");

        //	List<Roli> list = new List<Roli>();

        //	foreach (var entry in mapping)
        //		list.Add(entry.Roli);

        //	return _mapper.Map<IEnumerable<RoleDTO>>(list.AsEnumerable());
        //}

        public RolePaginate Paginate(int page)
        {
            if (page == 0)
                throw new ArgumentException("Invalid page");

            var roles = roliRepositoryInstance.GetAll();

            if (roles == null)
                throw new NullReferenceException("Unable to get roles");

            var nrResults = 5f;
            var nrPages = Math.Ceiling(roliRepositoryInstance.GetAll().Count() / nrResults);

            if (page > nrPages)
                throw new ArgumentException("Invalid page");

            var roleList = roliRepositoryInstance.Paginate(page, (int)nrResults, (int)nrPages);

            var roleDTOList = _mapper.Map<IEnumerable<RoleDTO>>(roleList);

            return new RolePaginate
            {
                list = roleDTOList,
                currentPage = page,
                pages = (int)nrPages
            };
        }

        public IEnumerable<RoleDTO> GetRoles(Guid userId)
        {
            var mapping = userRepositoryInstance.GetRolesOfUser(userId);
            if (mapping == null)
                throw new ArgumentException("User does not exist");

            List<Roli> list = new List<Roli>();

            foreach (var entry in mapping)
                list.Add(entry.Roli);

            return _mapper.Map<IEnumerable<RoleDTO>>(list.AsEnumerable());
        }
    }
}
