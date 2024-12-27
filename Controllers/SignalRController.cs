using CarRentalPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalPortal.Controllers
{
    public class SignalRController :Controller
    {
        public IActionResult Index()
        {
           
            return View();
        }
    }
}
