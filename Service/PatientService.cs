using HospitalManagement.DTOs;
using HospitalManagement.Repository;

namespace HospitalManagement.Service;


public interface IPatientService
{
    Task<IList<PatientDto>> GetPatientBySevereScore(int severeScore);
}
public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    public PatientService(IPatientRepository repository)
    {
        _patientRepository = repository;
    }
    public async Task<IList<PatientDto>> GetPatientBySevereScore(int s)
    {
        var patients = await _patientRepository.GetHighSeverePatients(s);
        var filteredPatients = patients
            .Select(p => new PatientDto
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                IsActive = p.IsActive,
                RegisteredDate = p.RegisteredDate,
                PatientBlankId = p.PatientBlankId
            }).ToList();

        return filteredPatients;
    }
}
