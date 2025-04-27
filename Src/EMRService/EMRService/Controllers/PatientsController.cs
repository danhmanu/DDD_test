using EMRService.EMRService.Application;
using EMRService.EMRService.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMRService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(CreatePatientDto dto)
        {
            var id = await _patientService.CreatePatientAsync(dto);
            return CreatedAtAction(nameof(GetPatient), new { id }, null);
        }
    }
}
