using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace RpgMvc.Controllers
{
    public class UsuariosController : Controller
    {
        public string uriBase = "http://localhost:5270/Usuarios/";
        //public string uriBase = "http://DanMarzo.somee.com/RpgApi/Usuarios/";
        //public string uriBase = "https://bsite.net/luizfernando987/Usuarios/";

        [HttpGet]
        public ActionResult Index()
        {
            return View("CadastroUsuario");
        }
        public async Task<IActionResult>
    }
}
