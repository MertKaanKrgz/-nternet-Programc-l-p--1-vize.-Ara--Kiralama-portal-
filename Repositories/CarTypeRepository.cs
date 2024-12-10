using CarRentalPortal.Models;
using System.Linq.Expressions;

namespace CarRentalPortal.Repositories
{
    //Buraya GenericRepository yazarak uzun metinlerden kurtuldum ve clean code yapmış oldum.
    public class CarTypeRepository : GenericRepository<CarType>, ICarTypeRepository
    {
        private AppDbContext _appDbcontext;
        public CarTypeRepository(AppDbContext appDbcontext) : base(appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public void Save()
        {
            _appDbcontext.SaveChanges();
        }

        public void Update(CarType carType)
        {
            _appDbcontext.Update(carType);
        }
    }
}
