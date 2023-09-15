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
        public void Create(PatientType patientType)
        {
            _context.PatientTypes.Add(patientType);
            _context.SaveChanges();
        }

        public IEnumerable<PatientType> GetList()
        {
            return _context.PatientTypes.ToList();
        }

        public PatientType GetPatientType(int? id)
        {
            var patientType = _context.PatientTypes.Where(x => x.Id == id).FirstOrDefault();
            if(patientType != null)
            {
                return patientType;  
            }
            return null;
        }

        public void lookUp()
        {
            _context.PatientTypes.ToLookup(x => x.Type);
        }
    }
}
