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
       


    }
}
