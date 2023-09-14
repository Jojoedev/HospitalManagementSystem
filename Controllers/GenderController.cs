using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    
    public class GenderController : Controller
    {
        private readonly IHospitalnterface _hospitalInterface;
        public GenderController(IHospitalnterface hospitalInterface)
        {
            _hospitalInterface = hospitalInterface;
        }

        [HttpGet]
        public ActionResult<Gender> GetList()
        { 
            var genderList = _hospitalInterface.GetList();
            return View(genderList);
        }

        [HttpGet("id")]
        public ActionResult<Gender> Details(int? id)
        {
            var getGender = _hospitalInterface.GetGender(id);
            return View(getGender);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult<Gender> Create(Gender gender)
        {
            if (ModelState.IsValid)
            {
                _hospitalInterface.Create(gender);
                
            }
        return RedirectToAction("GetList");

        }
    }
}
