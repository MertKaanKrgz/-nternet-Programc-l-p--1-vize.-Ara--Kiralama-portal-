using CarRentalPortal.Models;
using CarRentalPortal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarRentalPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarTypeRepository _carTypeRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ICarRepository carRepository, ICarTypeRepository carTypeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _carRepository = carRepository;
            _carTypeRepository = carTypeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

       
        public IActionResult Index()
        {
            List<Car> objCarList = _carRepository.GetAll(includeProps: "CarType").ToList();

            return View(objCarList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
