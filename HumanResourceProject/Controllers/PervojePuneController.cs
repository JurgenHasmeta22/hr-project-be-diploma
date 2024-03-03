using Domain.Contracts;
using DTO.PervojePuneDTO;
using DTO.RoleDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers {

	[ApiController]
	[Route("api/[controller]")]
	public class PervojePuneController : ControllerBase {

		private readonly IPervojePuneDomain _pervojePuneDomain;

		public PervojePuneController(IPervojePuneDomain pervojePuneDomain) {
			_pervojePuneDomain = pervojePuneDomain;
		}

		[HttpPost("addWorkExperience")]
		public IActionResult AddPP(PostPutPPDTO ppDTO) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var pervojePune = _pervojePuneDomain.AddPervojePune(ppDTO);
				
				if (pervojePune != null) {
					return Ok(pervojePune);
				}
				else {
					return NotFound();
				}
			}
			catch (Exception ex) {
				return StatusCode(600, ex);
			}
		}

		[HttpGet("getAllWorkExperiences")]
		public IActionResult GetAllPP() {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var pervojatPune = _pervojePuneDomain.GetAllPervojePune();
				
				if (pervojatPune != null) {
					return Ok(pervojatPune);
				}
				else {
					return NotFound();
				}
			}
			catch (Exception ex) {
				return StatusCode(500, ex);
			}
		}

		[HttpGet("getById{PPId}")]
		public IActionResult GetById(Guid PPId) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var pervojePune = _pervojePuneDomain.GetPervojePune(PPId);
				
				if (pervojePune != null) {
					return Ok(pervojePune);
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
		public IActionResult GetPPByName(string name) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var pervojePune = _pervojePuneDomain.GetPervojePune(name);
				
				if (pervojePune != null) {
					return Ok(pervojePune);
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

		[HttpDelete("removeWorkExperience/{PPId}")]
		public IActionResult RemovePPByID(Guid PPId) {
			try {
				if (!ModelState.IsValid)
					return BadRequest();
				
				_pervojePuneDomain.RemovePervojePune(PPId);
				
				return Ok();	
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(500, ex);
			}
		}

		[HttpPut("updateWorkExperience{PPId}")]
		public IActionResult UpdatePP(Guid PPId, PostPutPPDTO ppDTO) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}

				_pervojePuneDomain.UpdatePervojePune(PPId, ppDTO);
				
				return Ok();
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(500, ex);
			}
		}

		[HttpGet("getUserWorkExperience{userId}")]
		public IActionResult GetPPByUser(Guid userId) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var pps = _pervojePuneDomain.GetPPs(userId);
				
				if (pps != null) {
					return Ok(pps);
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

		[HttpGet("getUsersForWorkExperience{PPId}")]
		public IActionResult GetAllUsers(Guid PPId) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var users = _pervojePuneDomain.GetUsers(PPId);
				
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

		[HttpPost("assignWorkExperience")]
		public IActionResult AssignPP(UserPPDTO userPPDTO) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				
				_pervojePuneDomain.AssignPPToUser(userPPDTO);
				
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

				var list = _pervojePuneDomain.Paginate(page);

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