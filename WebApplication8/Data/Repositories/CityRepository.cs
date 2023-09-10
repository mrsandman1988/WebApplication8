using WebApplication8.Data.Entities;
using WebApplication8.Data.Repositories.Interfaces;

namespace WebApplication8.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly MyShopDataContext _context;
        public CityRepository(MyShopDataContext context)
        {
            _context = context;
        }
        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }
    }
}
