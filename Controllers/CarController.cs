using CarRentalPortal.Models;
using CarRentalPortal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CarRentalPortal.Controllers
{
    
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarTypeRepository _carTypeRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public CarController(ICarRepository carRepository, ICarTypeRepository carTypeRepository,IWebHostEnvironment webHostEnvironment)  
        {
            _carRepository = carRepository;
            _carTypeRepository = carTypeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Index()
        {          
            List<Car> objCarList = _carRepository.GetAll(includeProps:"CarType").ToList();

            return View(objCarList);
        }

        [Authorize(Roles = AppRole.Role_Admin)]
        public IActionResult AddUpdate(int? id)
        {

            IEnumerable<SelectListItem> CarTypeList = _carTypeRepository.GetAll().Select(k => new SelectListItem
            {
                Text = k.Name,
                Value = k.Id.ToString()
            });

            ViewBag.CarTypeList = CarTypeList;

            if (id== null || id==0)
            {
                //Ekleme
                return View();
            }
            else
            {
                //Güncelleme
                Car? carVt = _carRepository.Get(u => u.Id == id);
                if (carVt == null)

                {
                    return NotFound();
                }
                return View(carVt);
            }

           
        }

        [HttpPost]
        [Authorize(Roles = AppRole.Role_Admin)]
        public IActionResult AddUpdate(Car car, IFormFile? file) 
        {           
            if (ModelState.IsValid)
            {
               string wwwRootPath = _webHostEnvironment.WebRootPath;
                string carPath = Path.Combine(wwwRootPath, @"img");

                if (file !=null)

                { 

                using (var fileStream = new FileStream(Path.Combine(carPath, file.FileName),FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                car.ImageUrl = @"\img\" + file.FileName;
                } 

                if (car.Id == 0)
                {
                    _carRepository.Add(car);
                    TempData["basarili"] = "Yeni Araç Başarıyla Oluşturuldu!";
                }
                else
                {
                    _carRepository.Update(car);
                    TempData["basarili"] = "Araç Başarıyla Güncellendi!";
                }


                _carRepository.Save(); //SaveChanges() yapılmaz ise bilgiler veri tabanına eklenmez.                
                return RedirectToAction("Index", "Car");
            }
            return View();
        }
        /*
        public IActionResult Update(int? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            Car? carVt = _carRepository.Get(u=>u.Id==id);
            if (carVt == null)
            
            {
                return NotFound(); 
            }
            return View(carVt);
        }
        */
        /*
       [HttpPost]
       public IActionResult Update(Car car)
       {
           if (ModelState.IsValid)
           {

               _carRepository.Update(car);
               _carRepository.Save(); //SaveChanges() yapılmaz ise bilgiler veri tabanına eklenmez.
               TempData["basarili"] = "Araç Başarıyla Güncellendi!";
               return RedirectToAction("Index", "Car");
           }
           return View();
       }
        */

        public IActionResult Delete(int? id)
       {
           if (id == null || id == 0)
           {
               return NotFound();
           }
           Car? carVt = _carRepository.Get(u => u.Id == id);
           if (carVt == null)

           {
               return NotFound();
           }
           return View(carVt);
       }
       

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = AppRole.Role_Admin)]
        public IActionResult DeletePOST(int? id)
        {
            Car? car = _carRepository.Get(u => u.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            _carRepository.Delete(car);
            _carRepository.Save();
            TempData["basarili"] = "Araç Başarıyla Silindi!";
            return RedirectToAction("Index", "Car");
        }

    }
}
