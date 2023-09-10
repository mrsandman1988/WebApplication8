using WebApplication8.Data.Entities;

namespace WebApplication8.Data.Repositories.Interfaces
{
    public interface IUserRespository
    {
        void Add(User user);
        void Delete(User user);
        User GetById(int id);
        List<User> GetAll();
        IQueryable<User> GetAllQuerable();
        void SaveChanges();

    }
}
