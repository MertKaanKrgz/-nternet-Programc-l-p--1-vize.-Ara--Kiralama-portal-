 using CarRentalPortal.Models;
using CarRentalPortal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CarRentalPortal.Controllers
{
    [Authorize(Roles = AppRole.Role_Admin)]
    public class RentalController : Controller
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public RentalController(IRentalRepository rentalRepository, ICarRepository carRepository,IWebHostEnvironment webHostEnvironment)  
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            // List<Car> objCarList = _carRepository.GetAll().ToList();
            List<Rental> objRentalList = _rentalRepository.GetAll(includeProps:"Car").ToList();
            return View(objRentalList);
        }

        public IActionResult AddUpdate(int? id)
        {

            IEnumerable<SelectListItem> CarList = _carRepository.GetAll().Select(k => new SelectListItem                                                              {
                Text = k.Name,
                Value = k.Id.ToString()
            });

            ViewBag.CarList = CarList;

            if (id== null || id==0)
            {
                //Ekleme
                return View();
            }
            else
            {
                //Güncelleme
                Rental? rentalVt = _rentalRepository.Get(u => u.Id == id);
                if (rentalVt == null)

                {
                    return NotFound();
                }
                return View(rentalVt);
            }

           
        }

        [HttpPost]
        public IActionResult AddUpdate(Rental rental) 
        {           
            if (ModelState.IsValid)
            {
               

                if (rental.Id == 0)
                {
                    _rentalRepository.Add(rental);
                    TempData["basarili"] = "Yeni Kiralama İşlemi Başarıyla Oluşturuldu!";
                }
                else
                {
                    _rentalRepository.Update(rental);
                    TempData["basarili"] = "Kiralama Kaydı Başarıyla Güncellendi!";
                }


                _rentalRepository.Save(); //SaveChanges() yapılmaz ise bilgiler veri tabanına eklenmez.                
                return RedirectToAction("Index", "Rental");
            }
            return View();
        }
        // GET ACTION
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Rental? rentalvt = _rentalRepository.Get(u => u.Id == id);
            if (rentalvt == null)
            {
                return NotFound();
            }
            return View(rentalvt);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Rental? rental = _rentalRepository.Get(u => u.Id == id);
            if (rental == null)
            {
                return NotFound();
            }

            _rentalRepository.Delete(rental);
            _rentalRepository.Save();
            TempData["basarili"] = "Kiralama Kaydı Başarıyla Silindi!";
            return RedirectToAction("Index", "Rental");
        }

    }
}
