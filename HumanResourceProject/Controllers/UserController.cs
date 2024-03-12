using Domain.Concrete;
using Domain.Contracts;
using DTO.CertifikateDTO;
using DTO.EdukimDTO;
using DTO.UpdateDTO;
using DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HumanResourceProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserDomain _userDomain;

        public UserController(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        //[Authorize (Roles = "HR Manager")]
        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var users = _userDomain.GetAllUsers();

                if (users != null)
                {
                    return Ok(users);
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

        [HttpGet]
        [Route("{userId}")]
        public IActionResult GetUserById([FromRoute] Guid userId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var user = _userDomain.GetUserById(userId);

                if (user != null)
                    return Ok(user);

                return NotFound();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        [Route("{UserId}")]
        public IActionResult UpdateProject(Guid UserId, UserPostDTO user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var userupdated = _userDomain.PutUser(UserId, user);

                return Ok(userupdated);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("AssignProjectToUser/{UserId},{ProjektId}")]
        public IActionResult AssignProjectToUser(
            [FromRoute] Guid UserId,
            [FromRoute] Guid ProjektId,
            [FromBody] UserProjektPostDTO userprojekt
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (userprojekt is null)
                    return BadRequest("UserProjektPostDTO object is null");

                _userDomain.AddUserProject(UserId, ProjektId, userprojekt);
                return Ok();
                // return CreatedAtRoute("", new { id = createdProject.ProjektId,emri = createdProject.EmriProjekt,pershkrimi = createdProject.PershkrimProjekt }, createdProject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteMappedProjectToUser/{UserId},{ProjektId}")]
        public IActionResult DeleteMappedProjectToUser([FromRoute] Guid UserId, [FromRoute] Guid ProjektId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _userDomain.DeleteUserProject(UserId, ProjektId);
                return Ok();
                // return CreatedAtRoute("", new { id = createdProject.ProjektId,emri = createdProject.EmriProjekt,pershkrimi = createdProject.PershkrimProjekt }, createdProject);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("AssignLejeToUser/{UserId}")]
        public IActionResult CreateLeje([FromRoute] Guid UserId, [FromBody] LejePostDTO leje)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (leje is null)
                    return BadRequest("LejePostDTO object is null");

                if (_userDomain.KerkoLeje(UserId, leje) == false)
                    return Ok(false);
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteLejeOfUser/{LejeId}")]
        public IActionResult DeleteLeje(Guid LejeId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _userDomain.DeleteLeje(LejeId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        [Route("UpdateLeje/{LejeId}")]
        public IActionResult UpdateLeje(Guid LejeId, LejePostDTO leje)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _userDomain.UpdateLeje(LejeId, leje);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("ApproveLeje/{LejeId}")]
        public IActionResult ApproveLeje([FromRoute] Guid LejeId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _userDomain.ApproveLeje(LejeId);
                return Ok();
            }
            /*  catch (BalanceException ex)
              {
                  return StatusCode(500, ex);
              }*/
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("DisapproveLeje/{LejeId}")]
        public IActionResult DisapproveLeje([FromRoute] Guid LejeId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _userDomain.DisapproveLeje(LejeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("UpdateBalance/{UserId}")]
        public IActionResult UpdateBalance(Guid UserId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _userDomain.UpdateBalance(UserId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("AddUserEdukim/{UserId},{eduId}")]
        public IActionResult AddUserEdukim(
            [FromRoute] Guid UserId,
            [FromRoute] Guid eduId,
            [FromBody] UserEdukimPostDTO userEdukim
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (userEdukim is null)
                    return BadRequest("UserEdukim is null");

                _userDomain.AddUserEdukim(UserId, eduId, userEdukim);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteUserEdukim/{UserId},{EduId}")]
        public IActionResult DeleteUserEdukim([FromRoute] Guid UserId, [FromRoute] Guid EduId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _userDomain.DeleteUserEdukim(UserId, EduId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("AddUserCertifikate/{UserId},{CertId}")]
        public IActionResult AddUserCertifikate(
            [FromRoute] Guid UserId,
            [FromRoute] Guid CertId,
            [FromBody] UserCertifikatePostDTO userCertifikate
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (userCertifikate is null)
                    return BadRequest("UserCertifikate is null");

                _userDomain.AddUserCertifikate(UserId, CertId, userCertifikate);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteUserCertifikate/{UserId},{CertId}")]
        public IActionResult DeleteUserCertifikate([FromRoute] Guid UserId, [FromRoute] Guid CertId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _userDomain.DeleteUserCertifikate(UserId, CertId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("AddUserAftesi/{UserId},{aftesiId}")]
        public IActionResult AddUserAftesi(
            [FromRoute] Guid UserId,
            [FromRoute] Guid aftesiId,
            [FromBody] UserAftesiPostDTO userAftesi
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (userAftesi is null)
                    return BadRequest("UserAftesi is null");

                _userDomain.AddUserAftesi(UserId, aftesiId, userAftesi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteUserAftesi/{UserId},{AftesiId}")]
        public IActionResult DeleteUserAftesi([FromRoute] Guid UserId, [FromRoute] Guid AftesiId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _userDomain.DeleteUserAftesi(UserId, AftesiId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteUserPervojePune/{UserId},{PPId}")]
        public IActionResult DeleteUserPervojePune([FromRoute] Guid UserId, [FromRoute] Guid PPId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                _userDomain.DeleteUserPervojePune(UserId, PPId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("UpdateUserPervojePune/{UserId},{PPId}")]
        public IActionResult UpdateUserPervojePune(
            [FromRoute] Guid UserId,
            [FromRoute] Guid PPId,
            [FromBody] UserPervojePunePutDTO putDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var res = _userDomain.UpdateUserPervojePune(UserId, PPId, putDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("UpdateUserCertifikate/{UserId},{CertId}")]
        public IActionResult UpdateUserCertifikate(
            [FromRoute] Guid UserId,
            [FromRoute] Guid CertId,
            [FromBody] UserCertifikatePutDTO putDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var res = _userDomain.UpdateUserCertifikate(UserId, CertId, putDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("UpdateUserEdukim/{UserId},{EduId}")]
        public IActionResult UpdateUserEdukim(
            [FromRoute] Guid UserId,
            [FromRoute] Guid EduId,
            [FromBody] UserEdukimPutDTO putDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var res = _userDomain.UpdateUserEdukim(UserId, EduId, putDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("UpdateUserAftesi/{UserId},{AftesiId}")]
        public IActionResult UpdateUserAftesi(
            [FromRoute] Guid UserId,
            [FromRoute] Guid AftesiId,
            [FromBody] UserAftesiPutDTO putDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var res = _userDomain.UpdateUserAftesi(UserId, AftesiId, putDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("UpdateUserProjekt/{UserId},{ProjektId}")]
        public IActionResult UpdateUserProjekt(
            [FromRoute] Guid UserId,
            [FromRoute] Guid ProjektId,
            [FromBody] UserProjektPutDTO putDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var res = _userDomain.UpdateUserProjekt(UserId, ProjektId, putDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("UpdateUserRoli/{UserId},{RoliId}")]
        public IActionResult UpdateUserRoli(
            [FromRoute] Guid UserId,
            [FromRoute] Guid RoliId,
            [FromBody] UserRoliPutDTO putDTO
        )
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var res = _userDomain.UpdateUserRoli(UserId, RoliId, putDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
