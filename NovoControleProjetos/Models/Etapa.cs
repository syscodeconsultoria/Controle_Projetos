using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Etapa
    {
        public int Id_Etapa { get; set; }
        public string Ds_Etapa { get; set; }
        public bool Ativo { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime Data_Fim { get; set; }

    }
}