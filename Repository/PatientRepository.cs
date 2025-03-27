using HospitalManagement.DataAccess;
using HospitalManagement.DataAccess.Entities;
using HospitalManagement.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace HospitalManagement.Repository;

public interface IPatientRepository
    //: IRepository<Patient>
{
    Task<IEnumerable<Patient>> GetHighSeverePatients(int severeScore);
}
public class PatientRepository : IPatientRepository
{
    private readonly IMemoryCache _memoryCache;
    private readonly HospitalContext _context;
    public PatientRepository(HospitalContext context, IMemoryCache cache)
    {
        _context = context;
        _memoryCache = cache;
    }
    public async Task<IEnumerable<Patient>> GetHighSeverePatients(int severeScore)
    {
        return await _context.Patients
            .Include(x => x.PatientBlank)
            .Where(x => x.PatientBlank.SevereScore > severeScore)
            .ToListAsync();
    }
}
