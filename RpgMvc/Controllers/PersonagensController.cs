using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgMvc.Controllers
{
    public class PersonagensController : Controller
    {
        public string uriBase = "http://localhost:5270/Personagens/";
        //public string uriBase = "http://DanMarzo.somee.com/RpgApi/Personagens/";
        //public string uriBase = "https://bsite.net/luizfernando987/Personagens/";
    }
}
