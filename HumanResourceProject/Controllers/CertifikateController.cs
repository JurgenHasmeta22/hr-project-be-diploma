using Domain.Concrete;
using DTO.CertifikateDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertifikateController : ControllerBase
    {
        private CertifikateDomain _CertifikateDomain;

        public CertifikateController(CertifikateDomain certifikateDomain)
        {
            _CertifikateDomain = certifikateDomain;
        }

        [HttpGet]
        [Route("GetAllCertifikate")]
        public IActionResult GetAllCertifikate()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var certifikate = _CertifikateDomain.getAllCertifikate();

                if (certifikate != null)
                {
                    return Ok(certifikate);
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
        public IActionResult CreateCertifikate(CertifikatePostDTO certifikate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (certifikate is null)
                    return BadRequest("CertifikatePostDTO object is null");

                var CreateCertifikate = _CertifikateDomain.AddCertifikate(certifikate);

                return Ok(CreateCertifikate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("GetById/{CertId}")]
        public IActionResult GetCertifikateById([FromRoute] Guid CertId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var certifikates = _CertifikateDomain.GetCertifikateById(CertId);

                if (certifikates != null)
                    return Ok(certifikates);

                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("{CertId}")]
        public IActionResult DeleteCertifikate(Guid CertId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                    
                _CertifikateDomain.DeleteCertifikate(CertId);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{CertId}")]
        public IActionResult UpdateCertifikate(Guid CertId, CertifikatePostDTO certifikate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _CertifikateDomain.PutCertifikate(CertId, certifikate);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //[HttpPatch]
        //[Route("{CertId}")]
        //public IActionResult UpdateCertifikate(Guid CertId, JsonPatchDocument patchDoc)
        //{

        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest();
        //        }


        //        _CertifikateDomain.PatchCertifikate(CertId, patchDoc);

        //        return NoContent();

        //    }

        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex);
        //    }

        //}
    }
}
