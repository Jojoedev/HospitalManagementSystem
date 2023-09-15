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

//Add three properties, 1 for Patient's complains noted by Dr,2- Dr recommendation, 3 Lab test result, 4-Prescription. 