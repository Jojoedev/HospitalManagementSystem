using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientInterface _patientInterface;
        public PatientController(IPatientInterface patientInterface)
        {
            _patientInterface = patientInterface;
        }

        [HttpGet]
        public ActionResult<Patient> Index()
        {
            var patientList = _patientInterface.GetList();

            return View(patientList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult<Patient> Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientInterface.Create(patient);

            }
            return RedirectToAction("Index");

        }
    }
}
