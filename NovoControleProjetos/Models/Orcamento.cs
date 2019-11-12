using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Orcamento
    {
        public int? cod_orcamento { get; set; }
        public decimal total_aprovado { get; set; }
        public decimal total_realizado { get; set; }
        public decimal total_contratado { get; set; }
        public decimal total_aprovado_ano { get; set; }
        public decimal total_realizado_ano { get; set; }
        public int? id_iniciativa { get; set; }
    }
}