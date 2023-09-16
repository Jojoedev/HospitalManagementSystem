using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    public class PatientTypeController : Controller
    {
        private readonly IGenericInterface<PatientType> _genericInterface;
        public PatientTypeController(IGenericInterface<PatientType> genericInterface)
        {
            _genericInterface = genericInterface;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var list = _genericInterface.GetList();
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
                _genericInterface.Create(patientType);
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
