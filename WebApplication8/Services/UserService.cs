using Microsoft.AspNetCore.Identity;
using WebApplication8.Data.Repositories.Interfaces;
using WebApplication8.Services.Interfaces;
using WebApplication8.ViewModels;
using WebApplication8.Data.Entities;

namespace WebApplication8.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRespository _userRespository;
        public UserService(IUserRespository userRespository)
        {
            _userRespository= userRespository;
        }
        public void Add(UserAddEditViewModel model)
        {
            CheckIdNumber(model);
            var user = new User
            {
                IDNumber= model.IDNumber,
                CityId= model.CityId,
                FirstName= model.FirstName,
                Email= model.Email,
                LastName= model.LastName,
                RoleType= model.RoleType,
            };

            _userRespository.Add(user);
        }

        public void Update(UserAddEditViewModel model)
        {
            CheckIdNumber(model);
            var entity = _userRespository.GetById(model.Id);
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.RoleType = model.RoleType;
            entity.Email = model.Email;
            entity.CityId= model.CityId;
            _userRespository.SaveChanges();
        }

        private void CheckIdNumber(UserAddEditViewModel model)
        {
            bool checkIdCardExists
                = _userRespository.GetAllQuerable()
                .Any(p => p.IDNumber == model.IDNumber && p.Id != model.Id);
            if (checkIdCardExists)
            {
                throw new Exception("Id Number exists");
            }
        }
    }
}
