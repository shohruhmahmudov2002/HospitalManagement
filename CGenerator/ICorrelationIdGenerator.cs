namespace HospitalManagement.CGenerator;

public interface ICorrelationIdGenerator
{
    string Get();
    void Set(string correlationId);
}
