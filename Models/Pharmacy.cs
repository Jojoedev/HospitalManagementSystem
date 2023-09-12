namespace HospitalManagementSystem.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Medication { get; set; }  //This should be a list of medications to be prescribed to the patient.
        //There may be no need for Pharmacy class as the Service class has covered it.
    }
}
