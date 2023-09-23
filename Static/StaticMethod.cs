using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.Static
{
    public static class StaticMethod
    {

        public static SelectList GenderList { get; set; }
        public static SelectList PatientType { get; set; }
        /*public static void LoadData()
        {
            ViewBag.GenderList = new SelectList(_genericGender.GetList(), "Id", "Sex");
            ViewBag.PatientType = new SelectList(_genericPatientType.GetList(), "Id", "Type");
        }*/
    }
}
