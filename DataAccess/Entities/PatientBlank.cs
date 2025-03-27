namespace HospitalManagement.DataAccess.Entities;

public class PatientBlank
{
    public int PatientBlankId { get; set; }
    public int PatientId { get; set; }
    public string BlankIdentifier { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public int SevereScore { get; set; }

    public Patient Patient { get; set; }


    public string something2 { get; set; }
    public string something { get; set; }
}
