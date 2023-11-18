using Entities.Transports;
using Microsoft.AspNetCore.Mvc;
using RequisitionHandlers.Contracts;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRequisitionHandler _handler;
        public CategoryController(ICategoryRequisitionHandler handler)
        {
            _handler = handler;
        }


        [HttpPost]
        public IActionResult Add(CategoryTransport transport)
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
        public IActionResult Update(CategoryTransport transport)
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
        public IActionResult GetById(int id)
        {
            try
            {
                var entity = _handler.GetById(id);
                if (entity is not null)
                {

                    return Ok();
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
