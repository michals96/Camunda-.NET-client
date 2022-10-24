using Microsoft.AspNetCore.Mvc;
using poc.Dtos;
using poc.Services;

namespace poc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoCController : ControllerBase
    {
        private readonly ICamundaService _camundaService;
        private readonly ILogger<PoCController> _logger;

        public PoCController(ICamundaService camundaService, ILogger<PoCController> logger)
        {
            _camundaService = camundaService;
            _logger = logger;
        }

        [HttpPost(Name = "MoveForward")]
        public async Task<IActionResult> MoveForward(ProcessStateDto processStateDto)
        {
            var response = await _camundaService.Process(processStateDto.Id, processStateDto);

            //return BadRequest(response);
            
            return Ok(response);
        }
    }
}