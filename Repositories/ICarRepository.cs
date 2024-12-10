using CarRentalPortal.Models;

namespace CarRentalPortal.Repositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        void Update(Car car);
        void Save();
    }
}
    