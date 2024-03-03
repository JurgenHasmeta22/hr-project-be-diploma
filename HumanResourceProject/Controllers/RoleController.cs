using Domain.Contracts;
using DTO.RoleDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers {

	[ApiController]
	[Route("api/[controller]")]
	public class RoleController : ControllerBase {

		private readonly IRoliDomain _roliDomain;

		public RoleController(IRoliDomain roliDomain) {
			_roliDomain = roliDomain;
		}

		[HttpPost("addRole")]
		public IActionResult AddRole(PostPutRoleDTO roleDTO) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var role = _roliDomain.AddRole(roleDTO);
				
				if (role != null) {
					return Ok(role);
				}
				else {
					return NotFound();
				}
			}
			catch (Exception ex) {
				return StatusCode(600, ex);
			}
		}

		[HttpGet("getAllRoles")]
		public IActionResult GetAllRoles() {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var roles = _roliDomain.GetAllRoles();
				
				if (roles != null) {
					return Ok(roles);
				}
				else {
					return NotFound();
				}
			}
			catch (Exception ex) {
				return StatusCode(500, ex);
			}
		}

		[HttpGet("getById{id}")]
		public IActionResult GetById(Guid id) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var role = _roliDomain.GetRoleById(id);
				
				if (role != null) {
					return Ok(role);
				}
				else {
					return NotFound();
				}
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(500, ex);
			}
		}

		[HttpGet("getByName{name}")]
		public IActionResult GetByName(string name) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var role = _roliDomain.GetRoleByName(name);
				
				if (role != null) {
					return Ok(role);
				}
				else {
					return NotFound();
				}
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(500, ex);
			}
		}

		[HttpDelete("removeRole/{RoliId}")]
		public IActionResult RemoveRole(Guid RoliId) {
			try {
				if (!ModelState.IsValid)
					return BadRequest();

				_roliDomain.RemoveRole(RoliId);

				return Ok();
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(500, ex);
			}
		}

		[HttpPut("updateRole{id}")]
		public IActionResult UpdateRole(Guid id, PostPutRoleDTO roleDTO) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				
				_roliDomain.UpdateRole(id, roleDTO);
				
				return Ok();
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(500, ex);
			}
		}

		[HttpGet("getRolesOfUser{userId}")]
		public IActionResult GetRolesByUser(Guid userId) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var roles = _roliDomain.GetRoles(userId);
				
				if (roles != null) {
					return Ok(roles);
				}
				else {
					return NotFound();
				}
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(500, ex);
			}
		}

		[HttpGet("getUsersForRole{roleId}")]
		public IActionResult GetUsersByRole(Guid roleId) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}

				var users = _roliDomain.GetUsers(roleId);
				
				if (users != null) {
					return Ok(users);
				}
				else {
					return NotFound();
				}
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(500, ex);
			}
		}

		[HttpPost("addNewUserRole")]
		public IActionResult AssignRole(UserRoleDTO userRoleDTO) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}

				_roliDomain.AssignRoleToUser(userRoleDTO);
				return Ok();
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(600, ex);
			}
		}

		[HttpGet("paginate{page}")]
		public IActionResult Paginate(int page) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}

				var list = _roliDomain.Paginate(page);

				return Ok(list);
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (NullReferenceException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(600, ex);
			}
		}
	}
}

