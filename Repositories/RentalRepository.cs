using CarRentalPortal.Models;
using System.Linq.Expressions;

namespace CarRentalPortal.Repositories
{
    //Buraya GenericRepository yazarak uzun metinlerden kurtuldum ve clean code yapmış oldum.
    public class RentalRepository : GenericRepository<Rental>, IRentalRepository
    {
        private AppDbContext _appDbcontext;
        public RentalRepository(AppDbContext appDbcontext) : base(appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        public void Save()
        {
            _appDbcontext.SaveChanges();
        }

        public void Update(Rental rental)
        {
            _appDbcontext.Update(rental);
        }
    }
}
