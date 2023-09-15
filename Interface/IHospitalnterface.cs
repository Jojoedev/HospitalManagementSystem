using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Interface
{
    public interface IHospitalnterface
    {
        IEnumerable<Gender> GetList();

        Gender GetGender(int? id);

         void Create(Gender gender);
         void lookUp();
    }
}
