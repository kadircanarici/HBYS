using HBYS.Models;
using HBYS.Repository.Shared.Abstract;
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
    }
}
