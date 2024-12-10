using CarRentalPortal.Models;
using System.Linq.Expressions;

namespace CarRentalPortal.Repositories
{
    //Buraya GenericRepository yazarak uzun metinlerden kurtuldum ve clean code yapmış oldum.
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private AppDbContext _appDbcontext;
        public CarRepository(AppDbContext appDbcontext) : base(appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public void Save()
        {
            _appDbcontext.SaveChanges();
        }

        public void Update(Car car)
        {
            _appDbcontext.Update(car);
        }
    }
}
