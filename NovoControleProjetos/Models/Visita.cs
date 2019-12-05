using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Visita
    {
        public int? Id_Visita { get; set; }
        public string Agencia_Visitada { get; set; }
        public DateTime Data_Visita { get; set; }
    }
}