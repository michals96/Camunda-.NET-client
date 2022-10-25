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

        [HttpPost("/startLicenseProcess/{businessKey}", Name = "Start license process")]
        public async Task<IActionResult> StartLicensingProcess(String businessKey)
        {
            var response = await _camundaService.StartLicensingProcess(businessKey);
            _logger.LogInformation(response.ToString());
            return Ok("ok");
        }

        [HttpPost("/selectLicense/{processInstanceId}", Name = "Select license, fill form, upload docs")]
        public async void SelectLicense(String processInstanceId)
        {
            var response = await _camundaService.SelectLicense(processInstanceId);
        }

        [HttpGet("/healthCheck", Name = "HealthCheck")]
        public ActionResult healthCheck()
        {
            return Content("Application is UP!");
        }
    }
}