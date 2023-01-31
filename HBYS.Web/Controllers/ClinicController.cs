using HBYS.Models;
using HBYS.Repository.Shared.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HBYS.Web.Controllers
{
    public class ClinicController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ClinicController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            return Json(new { data = unitOfWork.Clinic.GetAll().ToList<Clinic>() });
        }
        [Authorize(Roles = "Admin")]

        public IActionResult Add(Clinic clinic)
        {
            unitOfWork.Clinic.Add(clinic);
            unitOfWork.Save();


            return Json(clinic);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            Clinic clinic = unitOfWork.Clinic.GetFirstOrDefault(x => x.Id == id);
            if (clinic != null)
            {
                unitOfWork.Clinic.Remove(clinic);
                unitOfWork.Save();
            }
            return Json(clinic);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IResult Edit(Clinic clinic)
        {
            Clinic asil = unitOfWork.Clinic.GetFirstOrDefault(x => x.Id == clinic.Id);

            asil.Name = clinic.Name;

            unitOfWork.Clinic.Update(asil);
            unitOfWork.Save();

            return Results.Ok("başarılı");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult GetById(Guid id)
        {
            Clinic clinic = unitOfWork.Clinic.GetFirstOrDefault(x => x.Id == id);
            return Json(clinic);
        }


    }
}
