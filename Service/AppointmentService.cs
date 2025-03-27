using HospitalManagement.DTOs;
using HospitalManagement.Repository.Interfaces;
using HospitalManagement.Service.Interfaces;
using HospitalManagement.Settings;
using Microsoft.Extensions.Options;

namespace HospitalManagement.Service;

public class AppointmentService : IAppointmentService
{
    private readonly IAppointmentRepository _appointmentRepository;
    private readonly AppointmentSetting _appointmentSetting;
    public AppointmentService(IAppointmentRepository appointmentRepository,
        IOptions<AppointmentSetting> appointmentSetting)
    {
        _appointmentRepository = appointmentRepository;
        _appointmentSetting = appointmentSetting.Value;
    }

    public bool CancelAppointment(DateTime dateTime)
    {
        TimeSpan timeRange = dateTime - DateTime.Now;
        return timeRange.TotalHours > _appointmentSetting.CancelationDeadlineHours;
    }
}
