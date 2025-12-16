using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppBlog.Models;
using Microsoft.Data.SqlClient; // Исправлено пространство имён


namespace WebAppBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Users()
        {
            var users = new List<User>();
            var cs = _config.GetConnectionString("DefaultConnection");

            using var conn = new SqlConnection(cs);
            conn.Open();

            using var cmd = new SqlCommand("SELECT Id, name, surname, email FROM Users", conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Surname = reader.GetString(2),
                    Email = reader.GetString(3)
                });
            }

            return View(users);
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
                var cs = _config.GetConnectionString("DefaultConnection");

                using var conn = new SqlConnection(cs);
                conn.Open();

                using var cmd = new SqlCommand(
                    "INSERT INTO Users (name, surname, email, age) VALUES (@Name,@Surname, @Email, @Age)", conn);

                cmd.Parameters.AddWithValue("@Name", usersModel.name);
                cmd.Parameters.AddWithValue("@Surname", usersModel.surname);
                cmd.Parameters.AddWithValue("@Email", usersModel.Email);
                cmd.Parameters.AddWithValue("@Age", usersModel.age); // если в таблице есть столбец Age

                cmd.ExecuteNonQuery(); // Выполняем вставку

                return RedirectToAction("Users"); // перенаправляем на список пользователей
            }

            return View(usersModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
