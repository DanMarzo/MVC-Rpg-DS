using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RpgMvc.Models;
using System.Net;
using System.Net.Http.Headers;

namespace RpgMvc.Controllers
{
    public class DisputasController : Controller
    {
        //public string uriBase = "http://localhost:5270/Disputas/";
        //public string uriBase = "http://DanMarzo.somee.com/RpgApi/Disputas/";
        public string uriBase = "https://bsite.net/luizfernando987/Disputas/";
        
        [HttpGet]   
        public async Task<ActionResult> IndexAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string token = HttpContext.Session.GetString("SessionTokenUsuario");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string uriBuscaPersonagens = "http://localhost:5270/Personagens/GetAll";
                //string uriBuscaPersonagens = "http://DanMarzo.somee.com/RpgApi/Personagens/GetAll";
                //string uriBuscaPersonagens = "https://bsite.net/luizfernando987/Personagens/GetAll";

                HttpResponseMessage response = await httpClient.GetAsync(uriBuscaPersonagens);
                string serialized = await response.Content.ReadAsStringAsync();
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    List<PersonagemViewModel> listaPersonagens = await Task.Run(() => JsonConvert.DeserializeObject<List<PersonagemViewModel>>(serialized));
                    ViewBag.ListaAtacantes = listaPersonagens;
                    ViewBag.ListaOponentes = listaPersonagens;
                    return View();
                }
                throw new Exception(serialized);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        
    }
}
