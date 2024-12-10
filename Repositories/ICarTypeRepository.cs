using CarRentalPortal.Models;

namespace CarRentalPortal.Repositories
{
    public interface ICarTypeRepository : IGenericRepository<CarType>
    {
        void Update(CarType carType);
        void Save();
    }
}
    