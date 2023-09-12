namespace HospitalManagementSystem.Models
{
    public class Patient : BaseEntity
    {

        public int? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }
    }
}
