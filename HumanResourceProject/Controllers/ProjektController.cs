using Domain.Contracts;
using DTO.UserDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace HumanResourceProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProjektController : ControllerBase
    {
        private readonly IProjektDomain _projektDomain;

        public ProjektController(IProjektDomain projektDomain)
        {
            _projektDomain = projektDomain;


        }


        [HttpGet]
        [Route("getAllProjects")]
        public IActionResult getAllProjects()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var projects = _projektDomain.getAllProjects();

                if (projects != null)
                {
                    return Ok(projects);
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

        public IActionResult CreateProject([FromBody] ProjektPostDTO projekt)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (projekt is null)
                    return BadRequest("ProjektPostDTO object is null");

                var createdProject = _projektDomain.AddProject(projekt);
                return Ok(createdProject);
                // return CreatedAtRoute("", new { id = createdProject.ProjektId,emri = createdProject.EmriProjekt,pershkrimi = createdProject.PershkrimProjekt }, createdProject);

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }


        [HttpDelete]
        [Route("Delete/{ProjektId}")]
        public IActionResult DeleteProject(Guid ProjektId)
        {


            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _projektDomain.DeleteProject(ProjektId);

                return NoContent();

            }

            catch (Exception ex)
            {
                return NotFound(ex);
            }



        }

        [HttpPut]
        [Route("Put/{ProjektId}")]
        public IActionResult UpdateProject(Guid ProjektId, ProjektPostDTO projekt)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                _projektDomain.PutProject(ProjektId, projekt);

                return NoContent();

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }



        [HttpGet]
        [Route("GetById/{ProjektId}")]
        public IActionResult GetProjectById([FromRoute] Guid ProjektId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                var project = _projektDomain.GetProjectById(ProjektId);

                if (project != null)
                    return Ok(project);

                return NotFound();
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("Patch/{ProjektId}")]
        public IActionResult UpdateProject(Guid ProjektId, JsonPatchDocument patchDoc)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }


                _projektDomain.PatchProject(ProjektId, patchDoc);

                return NoContent();

            }

            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

        }


    }


}

