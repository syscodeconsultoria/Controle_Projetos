using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Orcamento
    {
        public int? id_orcamento { get; set; }
        public string total_aprovado { get; set; }       
        public string total_realizado { get; set; }
        public string total_contratado { get; set; }
        public string total_aprovado_ano { get; set; }
        public string total_realizado_ano { get; set; }
        public int? id_iniciativa { get; set; }
    }
}