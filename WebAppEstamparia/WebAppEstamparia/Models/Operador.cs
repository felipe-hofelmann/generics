using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEstamparia.Models
{
    public class Operador: BaseModel
    {
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataAdmicao { get; set; }
    }
}