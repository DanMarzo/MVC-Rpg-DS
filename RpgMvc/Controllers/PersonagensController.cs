using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;
using RpgMvc.Models;

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
            return View("ListarPersonagem");
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarPersonagemAsync(PersonagemViewModel u)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                string uriComplementar = "PostAdd";
                var content = new StringContent(JsonConvert.SerializeObject(u));

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    TempData["Mensagem"] = string.Format($"O personagem {u.Nome}, foi cadastrado com sucesso");
                    return View("CadastroPersonagem");
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

        public async Task<IActionResult> ListarPersonagensAsyn()
        {
            string uriComplementar = "GetAll";

            HttpClient httpCliente = new HttpClient();

            var response = await httpCliente.GetAsync(uriBase + uriComplementar);

            var data = await response.Content.ReadAsStringAsync();

            List<PersonagemViewModel> lista = (List<PersonagemViewModel>)JsonConvert.DeserializeObject(data);

            return View(lista);
        }
    }
}
