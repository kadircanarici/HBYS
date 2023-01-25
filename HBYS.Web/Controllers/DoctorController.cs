using HBYS.Models;
using HBYS.Repository.Shared.Abstract;
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
        public IActionResult GetAll(Guid clinicId)
        {
            List<Doctor> dok = unitOfWork.Doctor.GetAll().Where(c => c.ClinicId == clinicId).ToList<Doctor>();
            return Json(dok );

        }
    }
}
