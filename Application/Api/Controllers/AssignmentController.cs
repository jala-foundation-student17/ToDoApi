using DomainEnums;
using Entities.Transports;
using Microsoft.AspNetCore.Mvc;
using RequisitionHandlers.Contracts;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentRequisitionHandler _handler;
        public AssignmentController(IAssignmentRequisitionHandler handler)
        {
            _handler = handler;
        }


        [HttpPost]
        public IActionResult Add(AssignmentTransport transport)
        {
            try
            {
                return Ok(_handler.Add(transport));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public IActionResult Update(AssignmentTransport transport)
        {
            try
            {

                return Ok(_handler.Update(transport));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            try
            {
                _handler.Remove(id);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetByStatus(EStatus id)
        {
            try
            {
                var assignments = _handler.GetByStatus(id);
                if (assignments.Any())
                {
                    return Ok(assignments);
                }
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetCompleted()
        {
            try
            {
                var assignments = _handler.GetCompleted();
                if (assignments.Any())
                {
                    return Ok(assignments);
                }
                return NoContent();

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetNotCompleted()
        {
            try
            {
                var assignments = _handler.GetNotCompleted();
                if (assignments.Any())
                {
                    return Ok(assignments);
                }
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetDueDateHigherThan(DateTime dateToGet)
        {
            try
            {
                var entity = _handler.GetDueDateHigherThan(dateToGet);
                if (entity is not null)
                {

                    return Ok(entity);
                }
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetDueDateLessThan(DateTime dateToGet)
        {
            try
            {
                var entity = _handler.GetDueDateLessThan(dateToGet);
                if (entity is not null)
                {

                    return Ok(entity);
                }
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {
                var entity = _handler.GetById(id);
                if(entity is not null)
                {

                    return Ok(entity);
                }
                return BadRequest("Entity does not exists.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
