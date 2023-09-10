using WebApplication8.Data.Entities;
using WebApplication8.Data.Repositories.Interfaces;

namespace WebApplication8.Data.Repositories
{
    public class UserRepository : IUserRespository
    {
        private readonly MyShopDataContext _context;
        public UserRepository(MyShopDataContext context) 
        { 
          _context= context;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
           _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public IQueryable<User> GetAllQuerable()
        {
            return _context.Users.AsQueryable();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
