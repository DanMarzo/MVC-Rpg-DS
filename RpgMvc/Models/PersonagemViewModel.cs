using Newtonsoft.Json;
using RpgMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RpgMvc.Models
{
    public class PersonagemViewModel
    {
        //[JsonProperty("id")]
        public int        Id           { get; set; }
        //[JsonProperty("nome")]
        public string     Nome         { get; set; }
        //[JsonProperty("pontosVida")]
        public int        PontosVida   { get; set; }
        //[JsonProperty("forca")]
        public int        Forca        { get; set; }
        //[JsonProperty("defesa")]
        public int        Defesa       { get; set; }
        //[JsonProperty("inteligencia")]
        public int        Inteligencia { get; set; }
        //[JsonProperty("classe")]
        public ClasseEnum Classe       { get; set; }
        public int        Disputas     { get; set; }
        public int        Vitorias     { get; set; }
        public int        Derrotas     { get; set; }

        internal static object JsonDesserializar(string data)
        {
            throw new NotImplementedException();
        }
    }
}
