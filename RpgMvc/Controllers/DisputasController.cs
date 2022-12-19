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
        public string uriBase = "http://DanMarzo.somee.com/RpgApi/Disputas/";
        //public string uriBase = "https://bsite.net/luizfernando987/Disputas/";
        
        [HttpGet]   
        public async Task<ActionResult> IndexAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                string token = HttpContext.Session.GetString("SessionTokenUsuario");
                
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //string uriBuscaPersonagens = "http://localhost:5270/Personagens/GetAll";
                string uriBuscaPersonagens = "http://DanMarzo.somee.com/RpgApi/Personagens/GetAll";
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
        
        [HttpPost]
        public async Task<ActionResult> IndexAsync(DisputaViewModel disputa)
        {
             try
             {
                HttpClient httpClient = new HttpClient();
                 string uriComplementar = "Arma";

                var content = new StringContent(JsonConvert.SerializeObject(disputa));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                 HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);
                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    disputa = await Task.Run(() => JsonConvert.DeserializeObject<DisputaViewModel>(serialized));
                    return RedirectToAction("Index", "Personagens");
                }
                throw new Exception(serialized);
             }
             catch (Exception ex)
             {
                 TempData["MensagemErro"] = ex.Message;
                 return RedirectToAction("Index");
             }
        }

        [HttpGet]
        public async Task<ActionResult> IndexDisputasAsync()
        {
            try
            {
                string uriComplementar = "Listar";
                HttpClient httpClient = new HttpClient();
                string token = HttpContext.Session.GetString("SessionTokenUsuario");

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                HttpResponseMessage response = await httpClient.GetAsync(uriBase + uriComplementar);
                string serialized = await response.Content.ReadAsStringAsync();

                if(response.StatusCode == HttpStatusCode.OK)
                {
                    List<DisputaViewModel> lista = await Task.Run(() => JsonConvert.DeserializeObject<List<DisputaViewModel>>(serialized));
                    return View(lista);
                }
                throw new Exception(serialized);
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
       
        [HttpGet]
        public async Task<ActionResult> ApagarDisputasAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                
                string token = HttpContext.Session.GetString("SessionTokenUsuario");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                string uriComplementar = "ApagarDisputas";
                HttpResponseMessage response = await httpClient.DeleteAsync(uriBase + uriComplementar);
                string serialized = await response.Content.ReadAsStringAsync();

                if(response.StatusCode == HttpStatusCode.OK)
                {
                    TempData["Mensagem"] = "Disputas apagadas com sucesso!";
                }
                throw new Exception(serialized);
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
            }
            return RedirectToAction("IndexDisputas", "Disputas");
        }

        [HttpGet]
        public async Task<ActionResult> IndexHabilidadesAsync()
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                string token = HttpContext.Session.GetString("SessionTokenUsuario");

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                //string uriBuscaPersonagens = "http://localhost:5270/Personagens/GetAll";
                string uriBuscaPersonagens = "http://DanMarzo.somee.com/RpgApi/Personagens/GetAll";
                //string uriBuscaPersonagens = "https://bsite.net/luizfernando987/Personagens/GetAll";

                HttpResponseMessage response = await httpClient.GetAsync(uriBuscaPersonagens);

                string serialized = await response.Content.ReadAsStringAsync();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    List<PersonagemViewModel> listaPersonagens = await Task.Run(() => JsonConvert.DeserializeObject<List<PersonagemViewModel>>(serialized));
                    ViewBag.ListaAtacantes = listaPersonagens;
                    ViewBag.ListaOponentes = listaPersonagens;
                }
                else
                    throw new Exception(serialized);

                //string uriBuscaHabilidade = "http://localhost:5270/PersonagemHabilidades/GetHabilidades";
                string uriBuscaHabilidade = "http://DanMarzo.somee.com/RpgApi/PersonagemHabilidades/GetHabilidades";
                //string uriBuscaHabilidade = "https://bsite.net/luizfernando987/PersonagemHabilidades/GetHabilidades";

                response = await httpClient.GetAsync(uriBuscaHabilidade);

                serialized = await response.Content.ReadAsStringAsync();

                if(response.StatusCode == HttpStatusCode.OK)
                {
                    List<HabilidadeViewModel> listaHabilidades = await Task.Run(() => JsonConvert.DeserializeObject<List<HabilidadeViewModel>>(serialized));
                    ViewBag.ListaHabilidades = listaHabilidades;
                }
                else
                    throw new Exception(serialized);

                return View("IndexHabilidades");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> IndexHabilidadesAsync(DisputaViewModel disputa)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                string uriComplementar = "Habilidade";
                var content = new StringContent(JsonConvert.SerializeObject(disputa));

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    disputa = await Task.Run(() => JsonConvert.DeserializeObject<DisputaViewModel>(serialized));
                    TempData["Mensagem"] = disputa.Narracao;

                    return RedirectToAction("Index", "Personagens");
                }
                throw new Exception(serialized);
            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<ActionResult> DisputaGeralAsync()
        {
            try
            {
                

                return RedirectToAction("Index", "Personagens");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index", "Personagens");
            }
        }
    }

}
