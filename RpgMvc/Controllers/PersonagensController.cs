using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgMvc.Controllers
{
    public class PersonagensController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
