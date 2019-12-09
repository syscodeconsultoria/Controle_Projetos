using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Farol
    {
        public int IdFarol { get; set; }
        public string Ds_Farol { get; set; }
        public string Cor_Farol { get; set; }
        public string IdFarol_CorFarol
        {
            get
            {
                return string.Format("{0} {1}", IdFarol, Cor_Farol);
            }
            
        }

        public string Comentario_Farol { get; set; }

        public int? Id_Comentario_Farol { get; set; }

        public DateTime? Data_Comentario { get; set; }

    }
}