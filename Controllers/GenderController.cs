using HospitalManagementSystem.Interface;
using HospitalManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers
{
    [Authorize(Roles ="IT Manager")]
    public class GenderController : Controller
    {
        private readonly IGenericInterface<Gender> _genericInterface;
        public GenderController(IGenericInterface<Gender> genericInterface)
        {
            _genericInterface = genericInterface;
        }

        [HttpGet]
        public ActionResult<Gender> GetList()
        {
            var genderList = _genericInterface.GetList();
            return View(genderList);
        }

        [HttpGet("id")]
        public ActionResult<Gender> Details(int? id)
        {
            var getGender = _genericInterface.GetOne(id);
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
                _genericInterface.Create(gender);
                
            }
        return RedirectToAction("GetList");

        }

        

    }
}
