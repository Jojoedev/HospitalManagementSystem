namespace HospitalManagementSystem.Models
{
    public class Patient : BaseEntity
    {

        public int? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }
        public int? ServiceId { get; set; }
        public virtual List<ServiceList>? ServiceOfferings { get; set; }


    }
}
