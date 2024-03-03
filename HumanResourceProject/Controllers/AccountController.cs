using Domain.Contracts;
using DTO.AccountDTO;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers {

	[ApiController]
	[Route("api/[controller]")]
	
	public class AccountController : ControllerBase {

		private readonly IAccountDomain _accountDomain;
		public AccountController(IAccountDomain accountDomain) {
			_accountDomain = accountDomain;
		}

		[HttpPost("register")]
		public IActionResult Register(RegisterDTO registerDTO) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var user = _accountDomain.Register(registerDTO);

				if (user != null) {
					return Ok(user);
				}
				else {
					return NotFound();
				}
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(600, ex);
			}
		}

		[HttpPost("login")]
		public IActionResult Login(LoginDTO loginDTO) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				var user = _accountDomain.Login(loginDTO);

				if (user != null) {
					return Ok(user);
				}
				else {
					return Unauthorized();
				}
			}
			catch (ArgumentException ex) {
				return Unauthorized(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(700, ex);
			}
		}

		[HttpPatch("changePassword")]
		public IActionResult ChangePassword(PasswordChangeDTO passwordChangeDTO) {
			try {
				if (!ModelState.IsValid) {
					return BadRequest();
				}
				
				_accountDomain.ChangePassword(passwordChangeDTO);

				return Ok();
			}
			catch (ArgumentException ex) {
				return BadRequest(ex.Message);
			}
			catch (Exception ex) {
				return StatusCode(700, ex);
			}
		}
	}
}
