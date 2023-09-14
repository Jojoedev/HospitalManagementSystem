using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interface
{
    public interface IPatientInterface
    {
        IEnumerable<Patient> GetList();

        Patient GetPatient(int? id);

        void Create(Patient patient);
    }
}
