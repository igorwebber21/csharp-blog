using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppBlog.Models;

namespace WebAppBlog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult Create(UsersModel usersModel)
        {
            // usersModel.age 

            Console.WriteLine(usersModel.age);

            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
