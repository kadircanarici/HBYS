using HBYS.Models;
using HBYS.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HBYS.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public PatientController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll()
        {
            return Json(new {data=unitOfWork.Patient.GetAll().ToList<Patient>()});
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Add(Patient patient)
        {
            unitOfWork.Patient.Add(patient);
            unitOfWork.Save();
            return Json(patient);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            Patient patient =unitOfWork.Patient.GetFirstOrDefault(x => x.Id == id);
            if(patient !=null)
            {
                unitOfWork.Patient.Remove(patient);
                unitOfWork.Save();
            }
            return Json(patient);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IResult Edit(Patient patient)
        {
            Patient asil = unitOfWork.Patient.GetFirstOrDefault(x => x.Id == patient.Id);
            asil.Address = patient.Address;
            asil.Phone = patient.Phone;
            asil.TC = patient.TC;
            asil.DoctorId = patient.DoctorId;
            
            asil.Name= patient.Name;
            unitOfWork.Patient.Update(asil);
            unitOfWork.Save();
            return Results.Ok("ok");

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(Guid id)
        {
            Patient patient = unitOfWork.Patient.GetFirstOrDefault(m => m.Id == id);
            return Json(patient);
        }
        public IActionResult GetByTC(string tc)
        {
            Patient patient = unitOfWork.Patient.GetFirstOrDefault(x => x.TC == tc);
            if (patient != null)
            {
                return Json(patient);
            }
            return Json(null);
        }

    }
}
