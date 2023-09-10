using WebApplication8.ViewModels;

namespace WebApplication8.Services.Interfaces
{
    public interface IUserService
    {
        void Add(UserAddEditViewModel model);
        void Update(UserAddEditViewModel model);
    }
}
