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

       
        public void lookUp()
        {
            _Context.Genders.ToLookup(x => x.Sex);
        }
    }
}
