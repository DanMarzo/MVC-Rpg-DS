using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using RpgMvc.Models;
using Microsoft.AspNetCore.Http;

namespace RpgMvc.Controllers
{
    public class PersonagensController : Controller
    {
        public string uriBase = "http://localhost:5270/Personagens/";
        //public string uriBase = "http://DanMarzo.somee.com/RpgApi/Personagens/";
        //public string uriBase = "https://bsite.net/luizfernando987/Personagens/";

        [HttpGet]
        public IActionResult IndexCreatePersonagem()
        {
            return View("CadastroPersonagem");
        }

        [HttpGet]

        public IActionResult IndexListarPersonagem()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPersonagemAsync(PersonagemViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "PostAdd";
                string token = HttpContext.Session.GetString("SessionTokenUsuario");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var content = new StringContent(JsonConvert.SerializeObject(u));

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    TempData["Mensagem"] = string.Format($"O personagem {u.Nome}, foi cadastrado com sucesso");
                    return RedirectToAction("Lista");
                }
                else
                {
                    throw new Exception(serialized);
                }

            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return View("CadastroPersonagem");
            }
        }
    
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            try
            { 
                string uriComplementar = "GetAll";
                HttpClient httpClient = new HttpClient();
                string token = HttpContext.Session.GetString("SessionTokenUsuario");
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await httpClient.GetAsync(uriBase + uriComplementar);
                string serialized = await response.Content.ReadAsStringAsync();
            
                if(response.StatusCode == HttpStatusCode.OK)
                {
                    List<PersonagemViewModel> listaPersonagem = await Task.Run(() => JsonConvert.DeserializeObject<List<PersonagemViewModel>>(serialized));
                    return View(listaPersonagem);
                }
                else
                {
                    throw new Exception(serialized);
                }

            }catch(Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
