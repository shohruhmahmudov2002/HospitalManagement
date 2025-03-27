﻿namespace HospitalManagement.DataAccess.Entities;

public class Doctor
{
    public Doctor()
    {
        Appointments = new List<Appointment>();
    }

    public int DoctorId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SpecialityId { get; set; }
    public bool IsActive { get; set; }
    //public DateTime RegisteredDate { get; set; }

    public Speciality Speciality { get; set; }
    public ICollection<Appointment> Appointments { get; set; }
}
