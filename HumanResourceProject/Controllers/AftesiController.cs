using Domain.Concrete;
using Domain.Contracts;
using DTO.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AftesiController : ControllerBase
    {
        private readonly IAftesiDomain _AftesiDomain;

        public AftesiController(IAftesiDomain AftesiDomain)
        {
            _AftesiDomain = AftesiDomain;
        }

        [HttpGet]
        [Route("GetAllAftesi")]
        public IActionResult GetAllAftesi()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var aftesi = _AftesiDomain.getAllAftesi();

                if (aftesi != null)
                {
                    return Ok(aftesi);
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
        public IActionResult CreateAftesi(AftesiPostDTO aftesi)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (aftesi is null)
                    return BadRequest("AftesiPostDTO object is null");

                var CreateAftesi = _AftesiDomain.AddAftesi(aftesi);

                return Ok(CreateAftesi);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("{AftesiId}")]
        public IActionResult GetAftesiById(Guid AftesiId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var Aftesi = _AftesiDomain.GetAftesiById(AftesiId);

                if (Aftesi != null)
                    return Ok(Aftesi);

                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{AftesiId}")]
        public IActionResult DeleteAftesi(Guid AftesiId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _AftesiDomain.DeleteAftesi(AftesiId);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{AftesiId}")]
        public IActionResult UpdateAftesi(Guid AftesiId, AftesiPostDTO aftesi)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                
                _AftesiDomain.PutAftesi(AftesiId, aftesi);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //[HttpPatch]
        //[Route("{AftesiId}")]
        //public IActionResult UpdateAftesi(Guid AftesiId, JsonPatchDocument patchDoc)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest();
        //        }
        //        _AftesiDomain.PatchAftesi(AftesiId, patchDoc);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex);
        //    }
        //}
    }
}
