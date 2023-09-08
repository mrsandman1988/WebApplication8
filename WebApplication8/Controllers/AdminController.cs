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

        #region UserManagment
        [HttpGet]
        public IActionResult AddUpdateUser(int? id)
        {
            User user = id.HasValue ? _context.Users.Find(id) : new();
            return View("AddUser",user);
        }

        [HttpPost]
        public IActionResult AddUpdateUser(User user)
        {
            bool checkIdCardExists
                = _context.Users.Any(p => p.IDNumber == user.IDNumber && p.Id !=user.Id);
            if(checkIdCardExists)
            {
                ViewBag.Error = "Id Number exists";
                return View("AddUser",user);
            }
            if(user.Id == 0)
            {
              _context.Users.Add(user);
            }
            else
            {
                var userEntity = _context.Users.Find(user.Id);
                userEntity.FirstName = user.FirstName;
                userEntity.LastName = user.LastName;
                userEntity.Email = user.Email;
                userEntity.IDNumber = user.IDNumber;
            }
            _context.SaveChanges();
            return RedirectToAction("UserIndex");
        }

        public IActionResult DeleteUser(int id)
        {
            var userEntity = _context.Users.Find(id);
            _context.Users.Remove(userEntity);
            _context.SaveChanges();
            return RedirectToAction(nameof(UserIndex));
        }
        public IActionResult UserIndex()
        {
            var users = _context.Users.ToList();
            
            return View(users);
        }

       

        
        #endregion
    }
}
