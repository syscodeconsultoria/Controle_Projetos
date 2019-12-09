using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Agencias
    {
        public int? id_agencia { get; set; }
        public int? cod_agencia { get; set; }
        public DateTime? data_visita { get; set; }
        public string nome_agencia { get; set; }
    }
}