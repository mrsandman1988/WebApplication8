using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using WebApplication8.Data.Entities;

namespace WebApplication8.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyShopDataContext _context;
        public AdminController(MyShopDataContext context)
        {
            _context= context;
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return View();
        }
    }
}
