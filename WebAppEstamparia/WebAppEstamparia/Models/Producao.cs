using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEstamparia.Models
{
    public class Producao : BaseModel
    {
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public Operador Operador { get; set; }
        public string Auxiliar { get; set; }
        public int Quantidade { get; set; }
        public int PH { get; set; }
    }
}