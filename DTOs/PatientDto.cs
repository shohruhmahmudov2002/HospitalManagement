namespace HospitalManagement.DTOs;

public class PatientDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly? DateOfBirth { get; set; }
    public bool IsActive { get; set; }
    public DateTime RegisteredDate { get; set; }
    public int? PatientBlankId { get; set; }
}
