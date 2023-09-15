using HospitalManagementSystem.AppDbContext;
using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientInterface _patientInterface;
        private readonly IHospitalnterface _hospitalnterface;
        private readonly IPatientType _patientType;
        public PatientController(IPatientInterface patientInterface, IHospitalnterface hospitalnterface, IPatientType patientType)
        {
            _patientInterface = patientInterface;
            _hospitalnterface = hospitalnterface;
            _patientType = patientType;
            
        }

        public SelectList genderList { get; set; }
        public SelectList patientType { get; set; }

        [HttpGet]
        public ActionResult Index()
        {
            _hospitalnterface.lookUp();
            _patientType.lookUp();
            var patientList = _patientInterface.GetList();
                                        

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
                _patientInterface.Create(patient);
            }
            return RedirectToAction("Index");
        }

        public void LoadData()
        {
            ViewBag.genderList = new SelectList(_hospitalnterface.GetList(), "Id", "Sex");
            ViewBag.patientType = new SelectList(_patientType.GetList(), "Id", "Type");
        }
    }
}
