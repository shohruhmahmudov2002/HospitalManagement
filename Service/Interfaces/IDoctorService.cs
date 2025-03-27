using HospitalManagement.DTOs;

namespace HospitalManagement.Service.Interfaces;

public interface IDoctorService
{
    Task CreateDoctor(CreateDoctorDto createDoctorDto);
    //Task<IEnumerable<CreateDoctorDto>> GetDoctors();
    Task SendPatientStatus();
}
