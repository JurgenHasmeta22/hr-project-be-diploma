using Domain.Contracts;
using DTO.UserDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LejeController : ControllerBase
    {
        private readonly ILejeDomain _lejeDomain;

        public LejeController(ILejeDomain lejeDomain)
        {
            _lejeDomain = lejeDomain;


        }

        [HttpGet]
        [Route("getAllLeje")]
        public IActionResult getAllLeje()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var lejet = _lejeDomain.getAllLeje();

                if (lejet != null)
                {
                    return Ok(lejet);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        


    }
}
