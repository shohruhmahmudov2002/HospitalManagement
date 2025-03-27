using HospitalManagement.DataAccess.Entities;
using HospitalManagement.DTOs;
using HospitalManagement.Repository;
using HospitalManagement.Repository.Interfaces;
using HospitalManagement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Service;

public class DoctorService : IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _petRepository;
    public DoctorService(IDoctorRepository doctorRepository, IPatientRepository repository)
    {
        _doctorRepository = doctorRepository;
        _petRepository = repository;
    }
    public async Task CreateDoctor(CreateDoctorDto doctorDto)
    {
        var doctor = doctorDto.ToEntity();

        await _doctorRepository.AddAsync(doctor);
        await _doctorRepository.SaveChangesAsync();
    }
    //public IList<CreateDoctorDto> GetDoctors()
    //{
    //    return _doctorRepository.GetAll().Select(doctor => doc).ToList();
    //}

    public async Task SendPatientStatus()
    {
        var highSeverePatients = await _petRepository.GetHighSeverePatients(5);
        var doctors = _doctorRepository.GetAll().Where(r => r.SpecialityId)
    }
}
