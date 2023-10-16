using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;



namespace HospitalManagementSystem.Controllers
{
    [Authorize(Roles ="IT Manager, Doctor 1")]
    public class DoctorController : Controller
    {
        private readonly IGenericInterface<Patient> _genericpatient;
        private readonly IGenericInterface<PatientType> _patientTypeGeneric;
        private readonly IGenericInterface<Gender> _genderGeneric;
        
        private readonly IPatientType _patientType;
        private readonly IHospitalnterface _hospitalnterface;

        public DoctorController(IGenericInterface<Patient> patientGeneric, IGenericInterface<PatientType> patientTypeGeneric,
                IGenericInterface<Gender> genderGeneric, IPatientType patientType, IHospitalnterface hospitalnterface)

        {
            _genericpatient = patientGeneric;
            _patientTypeGeneric = patientTypeGeneric;
            _genderGeneric = genderGeneric;
            _patientType = patientType;
            _hospitalnterface = hospitalnterface;
                
        }


        public SelectList GenderList { get; set; }
        public SelectList PatientType { get; set; }


        [HttpGet]
        public IActionResult Index()
        {

             _hospitalnterface.lookUp();
                 _patientType.lookUp();


           // var patient = _genericpatient.GetList();
                                         
              var patient = _genericpatient.GetList().OrderByDescending(x => x.ArrivalDate);
            return View(patient);
        }

        public ActionResult Review(int id)
        {
           LoadData();
            var patient = _genericpatient.GetOne(id);
            if(patient == null)
            {
                return NotFound();
            }
            return View(patient);

        }

        [HttpPost]
        public ActionResult Review(Patient patient)
        {

            if(ModelState.IsValid)
            {
                _hospitalnterface.lookUp();
                _patientType.lookUp();
                _genericpatient.Update(patient);
               
            }
            return RedirectToAction("Index");

        }

        public void LoadData()
        {
           ViewBag.GenderList = new SelectList(_genderGeneric.GetList(), "Id", "Sex");
           ViewBag.PatientType = new SelectList(_patientTypeGeneric.GetList(), "Id", "Type");
        }

    }
}
