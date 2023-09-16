using HospitalManagementSystem.AppDbContext;
using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Service
{
    public class IPatientTypeService : IPatientType
    {
        private readonly ApplicationDbContext _context;
        public IPatientTypeService(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public void lookUp()
        {
            _context.PatientTypes.ToLookup(x => x.Type);
        }
    }
}
