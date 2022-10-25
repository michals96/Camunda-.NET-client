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
            _camundaService.CompleteUserTaskWithNoVariables(processInstanceId);
            return Content("License selected!");
        }

        [HttpPost("/assignToSupport/{processInstanceId}", Name = "Assign license request to support team")]
        public ActionResult AssignToSupport(String processInstanceId)
        {
            _camundaService.CompleteUserTaskWithNoVariables(processInstanceId);
            return Content("Assigned to support!");
        }

        [HttpPost("/validateRequest/{processInstanceId}", Name = "Support validates request")]
        public ActionResult ValidateRequest(String processInstanceId)
        {
            _camundaService.CompleteUserTaskWithVariables(processInstanceId);
            return Content("Request validated!");
        }

        [HttpGet("/healthCheck", Name = "HealthCheck")]
        public ActionResult HealthCheck()
        {
            return Content("Application is UP!");
        }
    }
}