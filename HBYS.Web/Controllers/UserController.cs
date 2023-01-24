using HBYS.Data;
using HBYS.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HBYS.Web.Controllers
{
    public class UserController : Controller
    {
        public readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            User usr = _db.users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            if (usr != null)
            {
                List<Claim> userClaims = new List<Claim>();
                userClaims.Add(new Claim(ClaimTypes.Name, usr.UserName));
                userClaims.Add(new Claim(ClaimTypes.NameIdentifier, usr.Id.ToString()));
                userClaims.Add(new Claim(ClaimTypes.Role, "Admin"));

                var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("index");

            }
            else
            {
                return Json(user);
            }

        }
    }
}
    
