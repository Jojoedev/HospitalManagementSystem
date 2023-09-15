namespace HospitalManagementSystem.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string?  LastName { get; set; }
        public DateTime DOB { get; set; }

        public int Weight { get; set; }
        public float BodyTemperature { get; set; }

        public int Pulse { get; set; }

        public int SugarLevel { get; set; }

        public string? Address { get; set; }

        public bool isHMO { get; set; }
        
        public DateTime ArrivalDate { get; set; }
        public string? Complaints { get; set; }
        public string? DrNotes { get; set; }
        public string? TestResult { get; set; }
        public string? DrRemark { get; set; }


    }
    //Add three properties, 1 for Patient's complains noted by Dr,2- Dr recommendation, 3 Lab test result, 4-Prescription. 
}
