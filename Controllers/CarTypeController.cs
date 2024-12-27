using CarRentalPortal.Models;
using CarRentalPortal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CarRentalPortal.Controllers
{
    [Authorize(Roles = AppRole.Role_Admin)]
    public class CarTypeController : Controller
    {
        private readonly ICarTypeRepository _carTypeRepository;
       

        public CarTypeController(ICarTypeRepository context)
        {
            _carTypeRepository = context;
        }
        public IActionResult Index()
        {
            List<CarType> objCarTypeList = _carTypeRepository.GetAll().ToList();
            return View(objCarTypeList);
        }

        public IActionResult Add()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Add(CarType carType)
        {
            if (ModelState.IsValid)
            {

                _carTypeRepository.Add(carType);
                _carTypeRepository.Save(); //SaveChanges() yapılmaz ise bilgiler veri tabanına eklenmez.
                TempData["basarili"] = "Yeni Araç Türü Başarıyla Oluşturuldu!";
                return RedirectToAction("Index", "CarType");
            }
            return View();
        }

        public IActionResult Update(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            CarType? carTypeVt = _carTypeRepository.Get(u=>u.Id==id);
            if (carTypeVt == null)
            
            {
                return NotFound(); 
            }
            return View(carTypeVt);
        }

        [HttpPost]
        public IActionResult Update(CarType carType)
        {
            if (ModelState.IsValid)
            {

                _carTypeRepository.Update(carType);
                _carTypeRepository.Save(); //SaveChanges() yapılmaz ise bilgiler veri tabanına eklenmez.
                TempData["basarili"] = "Araç Türü Başarıyla Güncellendi!";
                return RedirectToAction("Index", "CarType");
            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            CarType? carTypeVt = _carTypeRepository.Get(u => u.Id == id);
            if (carTypeVt == null)

            {
                return NotFound();
            }
            return View(carTypeVt);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            CarType? carType = _carTypeRepository.Get(u => u.Id == id);
            if (carType == null)
            {
                return NotFound();
            }

            _carTypeRepository.Delete(carType);
            _carTypeRepository.Save();
            TempData["basarili"] = "Araç Türü Başarıyla Silindi!";
            return RedirectToAction("Index", "CarType");
        }

    }
}
