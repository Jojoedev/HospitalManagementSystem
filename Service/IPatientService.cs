using HospitalManagementSystem.AppDbContext;
using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Service
{
    public class IPatientService : IPatientInterface
    {
        private readonly ApplicationDbContext _Context;
        public IPatientService(ApplicationDbContext context)
        {
            _Context = context;
        }

        public void Create(Patient patient)
        {
            _Context.Patients.Add(patient);
            _Context.SaveChanges();
        }

        public Patient GetPatient(int? id)
        {
            var patient = _Context.Patients.Where(x => x.Id == id).FirstOrDefault();
            if (patient != null)
            {
                return patient;
            }
            return null;
        }

        public IEnumerable<Patient> GetList()
        {
            return _Context.Patients.ToList();
        }

        
    }
}
