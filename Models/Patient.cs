namespace HospitalManagementSystem.Models
{
    public class Patient : BaseEntity
    {

        public int? GenderId { get; set; }
        public virtual Gender? Gender { get; set; }

        public int? PatientTypeId { get; set; }
        public virtual PatientType? PatientType { get; set; }

    }
}
