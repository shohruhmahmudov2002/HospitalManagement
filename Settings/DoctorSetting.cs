namespace HospitalManagement.Settings
{

    public class DoctorSetting
    {
        public WorkTimeSetting WorkTime { get; set; }
    }
    public class WorkTimeSetting
    {
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
    }
}
