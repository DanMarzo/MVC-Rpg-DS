using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RpgMvc.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        [HttpPost]
        public async Task<ActionResult> RegistrarAsync(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "Registrar";
                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialize = await response.Content.ReadAsStringAsync();
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    TempData["Mensgem"] = string.Format($"O usuário {u.Username} foi cadastrado com sucesso, faça login para acessar");
                    return View("AutenticarUsuario");
                }
                else
                {
                    throw new Exception(serialize);
                }
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult IndexLogin()
        {
            return View("AutenticarUsuario");
        }

        [HttpPost]
        public async Task<ActionResult> AutenticarAsync(UsuarioViewModel u)
        {
            try
            {
                HttpClient cliente = new HttpClient();
                string uriComplementar = "Autenticar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await cliente.PostAsync(uriBase + uriComplementar, content);
                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContext.Session.SetString("SessionTokenUsuario", serialized);
                    TempData["Mensagem"] = string.Format($"Bem vindo {u.Username}");
                    return RedirectToAction("Index", "Personagens");
                }
                else
                    throw new Exception(serialized);
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return IndexLogin();
            }
        }
    }
}
