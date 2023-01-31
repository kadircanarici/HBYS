using HBYS.Models;
using HBYS.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HBYS.Web.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DoctorController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetAll(Guid clinicId)
        {
            List<Doctor> dok = unitOfWork.Doctor.GetAll().Where(c => c.ClinicId ==clinicId ).ToList<Doctor>();
            return Json(dok );

        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllDoctors()
        {
            List<Doctor> dok = unitOfWork.Doctor.GetAll().ToList<Doctor>();
            return Json(new { data = dok });

        }
        [Authorize(Roles = "Admin")]

        public IActionResult Add(Doctor doctor)
        {
            unitOfWork.Doctor.Add(doctor);
            unitOfWork.Save();


            return Json(doctor);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            Doctor vv = unitOfWork.Doctor.GetFirstOrDefault(x => x.Id == id);
            if (vv != null)
            {
                unitOfWork.Doctor.Remove(vv);
                unitOfWork.Save();
            }
            return Json(vv);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IResult Edit(Doctor doctor)
        {
            Doctor asil = unitOfWork.Doctor.GetFirstOrDefault(x => x.Id == doctor.Id);

            asil.Name = doctor.Name;
            
            asil.ClinicId = doctor.ClinicId;


            unitOfWork.Doctor.Update(asil);
            unitOfWork.Save();

            return Results.Ok("başarılı");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(Guid id)
        {
            Doctor vv = unitOfWork.Doctor.GetFirstOrDefault(x => x.Id == id);
            return Json(vv);
        }
    }
}
