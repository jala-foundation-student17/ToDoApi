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
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
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
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            try
            {

            return Ok(_handler.Remove(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            try
            {

            return Ok(_handler.GetById(id));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
