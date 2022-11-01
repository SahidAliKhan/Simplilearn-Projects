using Microsoft.AspNetCore.Mvc;
using bankdockerproject.Models;

namespace bankdockerproject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<LoginModel> value()
        {
            var users = new List<LoginModel>
            {
                new LoginModel{username="sahidxb",password="Hello@123"},
                new LoginModel{username="sahid",password="Hello@123"},
            };
            return users;
        }

        [HttpPost]
        public IActionResult Verify(LoginModel users)
        {
            var u = value();

            var ue = u.Where(u => u.username.Equals(users.username));

            var up = ue.Where(p => p.password.Equals(users.password));

            if (up.Count() == 1)
            {
                ViewBag.message = "Login Success";
                return View("Dashboard");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return View("Index");
            }
        }
    }
}