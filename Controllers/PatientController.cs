using HospitalManagementSystem.AppDbContext;
using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalManagementSystem.Controllers
{
    [Authorize(Roles = "IT Manager, Nurse")]
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

        public int SerialNumber = 1;
        
        [HttpGet]
        public ActionResult Index()
        {
            SerialNumber++;
            _hospitalnterface.lookUp();
            _patientType.lookUp();
            var patientList = _genericpatient.GetList().OrderByDescending(x => x.ArrivalDate);

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
            var number = _genericpatient.GetList().Last().SerialNumber;
            number++;
            patient.SerialNumber += number;

            

            DateTime date = DateTime.Now;
            var shortDate = date.Date;
            patient.ArrivalDate = shortDate;
            
            
            if (ModelState.IsValid)
            {
                _genericpatient.Create(patient);
            }
            return RedirectToAction("Index");
        }

               
        
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

        
        /*public ActionResult EditNurse(int id)
        {
            LoadData();
            var patient = _genericpatient.GetOne(id);
            if (patient == null)
            {
                NotFound();
            }
            return View(patient);

        }


        [HttpPost]
        public ActionResult EditNurse(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _genericpatient.Update(patient);

            }
            return RedirectToAction("Index");

        }
*/

        
        [HttpGet]
        public ActionResult DrView()
        {

            _hospitalnterface.lookUp();
            _patientType.lookUp();
            var drViewList = _genericpatient.GetList();
            return View(drViewList);
        }


        public void LoadData()
        {
            ViewBag.GenderList = new SelectList(_genericGender.GetList(), "Id", "Sex");
            ViewBag.PatientType = new SelectList(_genericPatientType.GetList(), "Id", "Type");
        }
    }
}
