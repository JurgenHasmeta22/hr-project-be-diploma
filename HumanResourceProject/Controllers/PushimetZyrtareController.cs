using Domain.Contracts;
using DTO.UserDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PushimetZyrtareController : ControllerBase
    {
        private readonly IPushimetZyrtareDomain _pushimetZyrtareDomain;

        public PushimetZyrtareController(IPushimetZyrtareDomain pushimetZyrtareDomain)
        {
            _pushimetZyrtareDomain = pushimetZyrtareDomain;


        }


        [HttpGet]
        [Route("getAllPushime")]
        public IActionResult getAllPushime()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var pushimet  = _pushimetZyrtareDomain.getAllPushime();

                if (pushimet != null)
                {
                    return Ok(pushimet);
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

        [HttpPost]

        public IActionResult CreatePushim([FromBody] PushimePostDTO pushim)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (pushim is null)
                    return BadRequest("ProjektPostDTO object is null");

                var createdPushim = _pushimetZyrtareDomain.AddPushim(pushim);
                return Ok(createdPushim);
                

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }


        [HttpDelete]
        [Route("{PushimId}")]
        public IActionResult DeletePushim(Guid PushimId)
        {


            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _pushimetZyrtareDomain.DeletePushim(PushimId);

                return NoContent();

            }

            catch (Exception ex)
            {
                return NotFound();
            }



        }
        
        [HttpPut]
        [Route("{PushimId}")]
        public IActionResult UpdatePushim(Guid PushimId, PushimePostDTO pushim)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                var pushimi= _pushimetZyrtareDomain.PutPushim(PushimId, pushim);

                return Ok(pushimi);

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }
        
        

        [HttpGet]
        [Route("{PushimId}")]
        public IActionResult GetPushimById([FromRoute] Guid PushimId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var pushimi = _pushimetZyrtareDomain.GetPushimById(PushimId);

                return Ok(pushimi);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        



    }


}

