using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Canal
    {
        public int Id_Canal { get; set; }
        public string Ds_Canal { get; set; }
        public bool Ativo { get; set; }
        public DateTime? Data_Canal { get; set; }
        
    }
}