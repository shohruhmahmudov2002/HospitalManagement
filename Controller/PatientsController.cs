using HospitalManagement.CGenerator;
using HospitalManagement.DTOs;
using HospitalManagement.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HospitalManagement.Controller;

[Route("api/[controller]")]
[ApiController]
public class PatientsController : ControllerBase
{
    private readonly DoctorSetting _options;
    private readonly DoctorSetting _doctorSetting;
    private readonly ILogger<PatientsController> _logger;
    private readonly ICorrelationIdGenerator _correlationIdGenerator;
    public PatientsController(IOptions<DoctorSetting> options, IConfiguration configuration, ILogger<PatientsController> logger
        ,ICorrelationIdGenerator correlationIdGenerator)
    {
        _options = options.Value;
        _doctorSetting = configuration.GetSection("DoctorsSetting").Get<DoctorSetting>();
        _logger = logger;
        _correlationIdGenerator = correlationIdGenerator;
    }

    //[HttpGet]
    //public IActionResult Get()
    //{
        
    //    return Ok($"{start}-{end}");
    //}

    [HttpPost("arrange-appointment")]
    public async Task<IActionResult> ArrangeAppointment([FromBody]ArrangeAppointmentDTO requestDto)
    {
        var time = TimeOnly.FromDateTime(requestDto.AppointmentDate);
        var start = _options.WorkTime.Start;
        var end = _options.WorkTime.End;

        if(!time.IsBetween(start,end))
        {
            _logger.LogWarning("Invalid time");
            return BadRequest("Invalid time");
        }

        _logger.LogInformation($"Correlation: {_correlationIdGenerator.Get()}");

        return Ok("Accepted");
    }
 
}
