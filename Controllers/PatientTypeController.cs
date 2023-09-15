using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PatientTypeController : Controller
    {
        private readonly IPatientType _patientType;
        public PatientTypeController(IPatientType patientType)
        {
            _patientType = patientType;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _patientType.GetList();
            return View(list);
        }


        public ActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Create(PatientType patientType)
        {
            if (ModelState.IsValid)
            {
                _patientType.Create(patientType);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
