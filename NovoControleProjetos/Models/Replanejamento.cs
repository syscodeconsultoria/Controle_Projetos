using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Replanejamento
    {
        public int? id_replanejamento { get; set; }
        public DateTime? data_replanejamento { get; set; }
        public string motivo_replanejamento { get; set; }        
    }
}