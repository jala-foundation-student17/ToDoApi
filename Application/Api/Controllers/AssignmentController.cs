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
            return Ok(_handler.Add(transport));
        }

        [HttpPut]
        public IActionResult Update(AssignmentTransport transport)
        {
            return Ok(_handler.Update(transport));
        }

        [HttpDelete]
        public IActionResult Remove(int id)
        {
            return Ok(_handler.Remove(id));
        }


        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok(_handler.GetById(id));
        }
    }
}
