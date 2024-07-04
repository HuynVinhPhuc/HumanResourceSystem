using BaseLibrary.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController(IParticipantInterface genericRepositoryInterface) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAll() => Ok(await genericRepositoryInterface.GetAll());

        [HttpGet("all/employee/{id}")]
        public async Task<IActionResult> GetAllEmployee(int id)
        {
            if (id <= 0) return BadRequest("Invalid request send");
            return Ok(await genericRepositoryInterface.GetAllByTrainingProgramId(id));
        }

        [HttpGet("all/trainingprogram/{id}")]
        public async Task<IActionResult> GetAllTrainingProgram(int id)
        {
            if (id <= 0) return BadRequest("Invalid request send");
            return Ok(await genericRepositoryInterface.GetAllByEmployeeId(id));
        }

        [HttpDelete("delete/{trainingProgramId}&{employeeId}")]
        public async Task<IActionResult> Delete(int trainingProgramId, int employeeId)
        {
            if ((trainingProgramId <= 0) || (employeeId <= 0)) return BadRequest("Invalid request send");
            return Ok(await genericRepositoryInterface.DeleteById(trainingProgramId, employeeId));
        }

        [HttpGet("single/{trainingProgramId}&{employeeId}")]
        public async Task<IActionResult> GetById(int trainingProgramId, int employeeId)
        {
            if ((trainingProgramId <= 0) || (employeeId <= 0)) return BadRequest("Invalid request send");
            return Ok(await genericRepositoryInterface.GetById(trainingProgramId, employeeId));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Participant model)
        {
            if (model is null) return BadRequest("Bad request made");
            return Ok(await genericRepositoryInterface.Insert(model));
        }
    }
}
