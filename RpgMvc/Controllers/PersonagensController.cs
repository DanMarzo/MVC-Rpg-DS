using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RpgMvc.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RpgMvc.Controllers
{
    public class PersonagensController : Controller
    {
        public string uriBase = "http://localhost:5270/Usuarios/";
        //public string uriBase = "http://DanMarzo.somee.com/RpgApi/Usuarios/";
        //public string uriBase = "https://bsite.net/luizfernando987/Usuarios/";

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            string uriComplementar = "GetAll";
            try
            {
                HttpClient httpClient = new HttpClient();
                string token = HttpContext.Session.GetString("SessionTokenUsuario");// esse miseravel gera cabeçalho 
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage response = await httpClient.GetAsync(uriBase + uriComplementar);
                string serialize = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    List<PersonagemViewModel> listaPersonagem = await Task.Run(() => JsonConvert.DeserializeObject<List<PersonagemViewModel>>(serialize));
                    return View(listaPersonagem);
                }
                else
                    throw new Exception(serialize);

            }
            catch(Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }



    }
}
