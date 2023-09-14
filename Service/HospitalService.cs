using HospitalManagementSystem.AppDbContext;
using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Service
{
    public class HospitalService : IHospitalnterface
    {
        private readonly ApplicationDbContext _Context;
        public HospitalService(ApplicationDbContext context)
        {
            _Context = context;
        }

        public void Create(Gender gender)
        {
            _Context.Genders.Add(gender);
            _Context.SaveChanges();

           
        }

        public Gender GetGender(int? id)
        {
            var gender = _Context.Genders.Where(x => x.Id == id).FirstOrDefault();
            if (gender != null)
            {
                return gender;
            }
            return null;
        }

        public IEnumerable<Gender> GetList()
        {
            return _Context.Genders.ToList();
        }
    }
}
