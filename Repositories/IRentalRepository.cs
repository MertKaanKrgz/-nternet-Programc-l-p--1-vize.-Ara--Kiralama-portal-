using CarRentalPortal.Models;

namespace CarRentalPortal.Repositories
{
    public interface IRentalRepository : IGenericRepository<Rental>
    {
        void Update(Rental rental);
        void Save();
    }
}
    