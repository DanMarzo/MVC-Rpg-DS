using Microsoft.AspNetCore.Mvc;

namespace RpgMvc.Controllers
{
    public class DisputasController : Controller
    {
        //public string uriBase = "http://localhost:5270/Disputas/";
        //public string uriBase = "http://DanMarzo.somee.com/RpgApi/Disputas/";
        public string uriBase = "https://bsite.net/luizfernando987/Disputas/";

        public IActionResult Index()
        {
            return View();
        }
    }
}
