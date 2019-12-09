using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Visita
    {
        public int? Id_Visita { get; set; }
        public int? Cod_Agencia { get; set; }
        public string Nome_Agencia { get; set; }
        public DateTime? Data_Visita { get; set; }

    }
}