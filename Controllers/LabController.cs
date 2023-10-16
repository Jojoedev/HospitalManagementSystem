using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.Controllers
{
    [Authorize(Roles = "IT Manager, Lab")]
    public class LabController : Controller
    {

        private readonly IGenericInterface<Patient> _genericpatient;
        private readonly IGenericInterface<PatientType> _patientType;
        private readonly IGenericInterface<Gender> _gender;
        private readonly IHospitalnterface _hospitalnterface;
        private readonly IPatientType _patientTy;

        public LabController(IGenericInterface<Patient> patientGeneric, 
            IGenericInterface<PatientType> patientType,
            IHospitalnterface hospitalnterface,
            IPatientType patienTy,
            IGenericInterface<Gender> gender)
        {
            _genericpatient = patientGeneric;
            _patientType = patientType;
            _gender = gender;
            _hospitalnterface = hospitalnterface;
            _patientTy = patienTy;


        }

        public SelectList GenderList { get; set; }
        public SelectList PatientType { get; set; }


        [HttpGet]
        public ActionResult Index()
        {
            _patientTy.lookUp();
            _hospitalnterface.lookUp();
            var patientList = _genericpatient.GetList().OrderByDescending(x => x.ArrivalDate);

            return View(patientList);
        }

        public IActionResult Update(int id)
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

        public IActionResult Update(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _genericpatient.Update(patient);
               
            }
            return RedirectToAction("Index");
        }

        public void LoadData()
        {
            ViewBag.PatientType = new SelectList(_patientType.GetList(), "Id", "Type");
            ViewBag.GenderList = new SelectList(_gender.GetList(), "Id", "Sex");
        }
    }
}
