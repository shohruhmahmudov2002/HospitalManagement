using HospitalManagement.CGenerator;
using HospitalManagement.DTOs;
using HospitalManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ICorrelationIdGenerator _correlationIdGenerator;
        private readonly ILogger<AppointmentController> _logger;
        public AppointmentController(IAppointmentService appointmentService, ICorrelationIdGenerator correlationIdGenerator)
        {
            _appointmentService = appointmentService;

            _correlationIdGenerator = correlationIdGenerator;

        }


        [HttpPost("CancelAppointmentCheck")]
        public IActionResult CancelAppointmentCheckAsync([FromBody] CancelAppointmentDto request)
        {
            if(_appointmentService.CancelAppointment(request.AppointmentDate))
            {
                return Ok("Appointment cancelled");
            }
            return BadRequest("Appointment will not be cancelled");
        }


    }
}
