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

        [HttpPost("/startLicenseProcess/{businessKey}", Name = "Start license process")]
        public async Task<IActionResult> StartLicensingProcess(String businessKey)
        {
            await _camundaService.StartLicensingProcess(businessKey);
            return Ok(_camundaService.GetInstanceIdByBusinessKey(businessKey));
        }

        [HttpPost("/selectLicense/{processInstanceId}", Name = "Select license, fill form, upload docs")]
        public ActionResult SelectLicense(String processInstanceId)
        {
            _camundaService.SelectLicense(processInstanceId);
            return Content("License selected!");
        }

        [HttpGet("/healthCheck", Name = "HealthCheck")]
        public ActionResult HealthCheck()
        {
            return Content("Application is UP!");
        }
    }
}