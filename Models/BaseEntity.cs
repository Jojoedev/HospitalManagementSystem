using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }

        
        [Display(Name = "FName")]
        public string? FirstName { get; set; }

        [Display(Name = "LName")]
        public string?  LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        public int Weight { get; set; }
        [Display(Name = "Temp")]
        public float BodyTemperature { get; set; }

        public int Pulse { get; set; }

        [Display(Name = "Sugar")]

        public int SugarLevel { get; set; }

        public string? Address { get; set; }

        public bool isHMO { get; set; }

        [Display(Name = "Date")]
        public DateTime ArrivalDate { get; set; }
        public string? Complaints { get; set; }
        public string? DrNotes { get; set; }
        public string? TestResult { get; set; }
        public string? DrRemark { get; set; }
        public string? NameOfDoctor { get; set; }


    }
    //Add three properties, 1 for Patient's complains noted by Dr,2- Dr recommendation, 3 Lab test result, 4-Prescription. 
}
