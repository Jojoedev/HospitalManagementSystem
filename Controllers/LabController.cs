using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Authorize(Roles = "IT Manager, Lab")]
    public class LabController : Controller
    {
        
        private readonly IGenericInterface<Patient> _patientGeneric;

        public LabController(IGenericInterface<Patient> patientGeneric)
        {
                _patientGeneric = patientGeneric;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var patientList = _patientGeneric.GetList();

            return View(patientList);
        }

        public IActionResult Update(int id)
        {
            var patient = _patientGeneric.GetOne(id);
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
                _patientGeneric.Update(patient);
               
            }
            return RedirectToAction("Index");
        }

    }
}
