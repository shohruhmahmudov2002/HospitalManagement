using HospitalManagement.DataAccess.Entities;

namespace HospitalManagement.DTOs;

public class CreateDoctorDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SpecialityId { get; set; }

    public Doctor ToEntity()
    {
        return new Doctor()
        {
            FirstName = FirstName,
            LastName = LastName,
            IsActive = true,
            SpecialityId = SpecialityId
        };
    }

}
