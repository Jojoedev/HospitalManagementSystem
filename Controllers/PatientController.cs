using HospitalManagementSystem.AppDbContext;
using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.Controllers
{
    [Authorize(Roles = "IT Manager")]
    public class PatientController : Controller
    {
        private readonly IGenericInterface<Patient> _genericpatient;
        private readonly IGenericInterface<PatientType> _genericPatientType;
        private readonly IGenericInterface<Gender> _genericGender;
        
        private readonly IPatientType _patientType;
        private readonly IHospitalnterface _hospitalnterface;

        public PatientController(IGenericInterface<Patient> genericpatient, 
            IGenericInterface<PatientType> genericPatientType,
            IGenericInterface<Gender> genericGender, IPatientType patientType, 
            IHospitalnterface hospitalnterface)
        {
            _genericpatient = genericpatient;
            _genericPatientType = genericPatientType;
            _genericGender = genericGender;
            _patientType = patientType;
            _hospitalnterface = hospitalnterface;
            
        }

        public SelectList genderList { get; set; }
        public SelectList patientType { get; set; }


        [HttpGet]
        public ActionResult Index()
        {
            _hospitalnterface.lookUp();
            _patientType.lookUp();
            var patientList = _genericpatient.GetList();      

            return View(patientList);
        }
                
        public IActionResult Create()
        {
            LoadData();
            return View();
        }

        [HttpPost]
        public ActionResult<Patient> Create(Patient patient)
        {
            patient.ArrivalDate = DateTime.Now;
            if (ModelState.IsValid)
            {
                _genericpatient.Create(patient);
            }
            return RedirectToAction("Index");
        }

        public void LoadData()
        {
            ViewBag.genderList = new SelectList(_genericGender.GetList(), "Id", "Sex");
            ViewBag.patientType = new SelectList(_genericPatientType.GetList(), "Id", "Type");
        }
    }
}
