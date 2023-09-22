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

        public SelectList GenderList { get; set; }
        public SelectList GatientType { get; set; }


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
            ViewBag.GenderList = new SelectList(_genericGender.GetList(), "Id", "Sex");
            ViewBag.PatientType = new SelectList(_genericPatientType.GetList(), "Id", "Type");
        }

               
        /*public ActionResult Edit(int id)
        {
            LoadData();
            var patient = _genericpatient.GetOne(id);
           

            if (patient == null)
            {
                return NotFound();
            }
           
            return View(patient);

        }

*/
       /* [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            var obj = _genericpatient.GetOne(patient.Id);
            if(obj  == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _genericpatient.Update(patient);
                return NoContent();
            }
            return RedirectToAction("Index");
           
        }*/

        public ActionResult Edit(int id)
        {
            LoadData();
            var patient = _genericpatient.GetOne(id);
            if(patient == null)
            {
                NotFound();
            }
            return View(patient);

        }

        [HttpPost]
        public ActionResult Edit(Patient patient)
        {
            if(ModelState.IsValid)
            {
                _genericpatient.Update(patient);
                
            }
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult DrView()
        {

            _hospitalnterface.lookUp();
            _patientType.lookUp();
            var drViewList = _genericpatient.GetList();
            return View(drViewList);
        }

    }
}
