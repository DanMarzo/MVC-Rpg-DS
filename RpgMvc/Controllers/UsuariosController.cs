using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Index()
        {
            return View("CadastrarUsuario");
        }


        [HttpPost]
        public async Task<IActionResult> RegistrarAsync(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "Registrar";

                var content = new StringContent(JsonConvert.SerializeObject(u));

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    TempData["Mensagem"] =
                        string.Format($"Usuário {u.UserName} Registrado com sucesso! Faça o login para acessar.");
                    return View("AutenticarUsuario");
                }
                else
                {
                    throw new Exception(serialized);
                }
            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }


        [HttpGet]//Esse get estava la em cima Voltar la caso de problema
        public IActionResult IndexLogin()
        {
            return View("AutenticarUsuario");
        }
        [HttpPost]
        public async Task<IActionResult> AutenticarAsync(UsuarioViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "Autenticar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    HttpContext.Session.SetString("SessioTokenUsuario", serialized);
                    TempData["Mensagem"] = string.Format($"Bem-vindo {u.UserName}");
                    return RedirectToAction("Index", "Personsagens");
                }
                else
                {
                    throw new System.Exception(serialized);
                }


            }
            catch (System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return IndexLogin();
            }
        }
    }
}
