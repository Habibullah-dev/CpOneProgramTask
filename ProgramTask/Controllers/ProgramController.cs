using Microsoft.AspNetCore.Mvc;
using ProgramTask.Dtos.Requests;
using ProgramTask.Models;
using ProgramTask.Services.Contracts;

namespace ProgramTask.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramRepository _programRepository;

        public ProgramController(IProgramRepository programRepository)
        {
            _programRepository = programRepository;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var item = await _programRepository.GetEmployerProgramAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }


        [HttpPost("employer")]
        public async Task<IActionResult> Create(EmployerProgramRequestDto item)
        {
            EmployerProgram program = await _programRepository.AddProgramAsync(item);

            return CreatedAtAction(nameof(Get), new { id = program.Id }, program);
        }



        [HttpPost("client/{programId}")]
        public async Task<IActionResult> Create(string programId, PersonalInfo personalInfo)
        {
            await _programRepository.SaveClientProgramInfoAsync(programId, personalInfo);

            return Ok();
        }



    }
}
