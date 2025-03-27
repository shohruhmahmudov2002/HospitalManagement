namespace HospitalManagement.DTOs
{
    public class ArrangeAppointmentDTO
    {
        public bool IsActive { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

    }
}
