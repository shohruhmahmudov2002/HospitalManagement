using HospitalManagement.DTOs;

namespace HospitalManagement.Service.Interfaces;

public interface IAppointmentService
{
    bool CancelAppointment(DateTime dateTime);
}
