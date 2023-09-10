using Microsoft.AspNetCore.Mvc;
using WebApplication8.Data;
using WebApplication8.Data.Entities;
using WebApplication8.ViewModels;
using WebApplication8.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using WebApplication8.Services.Interfaces;

namespace WebApplication8.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService= userService;
        }

        #region UserManagment
        [HttpGet]
        public IActionResult AddUpdateUser(int? id)
        {
            return View("AddUser", new UserAddEditViewModel());
            //User user = id.HasValue ? _userRepository.GetById(id.Value) : new();
            //ViewBag.Cities = _context.Cities.ToList() ;
            //return View("AddUser",user);
        }

        [HttpPost]
        public IActionResult AddUpdateUser(UserAddEditViewModel model)
        {
            try
            {
                if(model.Id== 0)
                {
                    _userService.Add(model);
                }
                else
                {
                    _userService.Update(model);
                }
            }
            catch(Exception ex)
            {
                   ViewBag.Error = ex.Message;
                    return View("AddUser",model);
            }
            
           
            
           
            return RedirectToAction("UserIndex");
        }

        public IActionResult DeleteUser(int id)
        {
            return View();
            //var userEntity = _userRepository.GetById(id);
            //_userRepository.Delete(userEntity);
           
            //return RedirectToAction(nameof(UserIndex));
        }
        public IActionResult UserIndex(UserFilterModel model)
        {
            //ViewBag.Filter = model;
            //var users = _userRepository.GetAll()
            //    .Where(u => (model.FirstName == null || u.FirstName.ToLower() == model.FirstName.ToLower()
            //    && (model.LastName == null || u.LastName.ToLower() == model.LastName.ToLower())
            //    &&(model.Email == null || u.Email.ToLower() == model.Email.ToLower())
            //    && (model.IdNumber == null || u.IDNumber.ToLower() == model.IdNumber.ToLower())))
            //    .ToList();
            //    ;

            //return View(users);
            return View(new List<User>());
        }

       

        
        #endregion
    }
}
