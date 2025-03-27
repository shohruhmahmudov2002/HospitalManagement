using System.Text.Json;
using HospitalManagement.DTOs;
using HospitalManagement.Filters;
using HospitalManagement.Service;
using HospitalManagement.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [LongActionFilter]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IConfiguration _configuration;
        private readonly PdpService _pdpService;
        public DoctorController(IDoctorService doctorService, IConfiguration configuration, PdpService pdpService)
        {
            _doctorService = doctorService;
            _configuration = configuration;
            _pdpService = pdpService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto createDoctorDto)
        {
            await _doctorService.CreateDoctor(createDoctorDto);
            return Created();
        }

        

        [HttpGet("pdp-servie")]
        public async Task<IActionResult> GetSettings()
        {
            return Ok(await _pdpService.GetPdpData());
        }

    }
}
