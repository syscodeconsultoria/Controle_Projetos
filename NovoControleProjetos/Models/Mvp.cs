using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Mvp
    {
        public int? Id_Mvp { get; set; }
        public int? Id_Iniciativa { get; set; }
        public string Nome_Mvp { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="0:dd/MM/yyyy")]
        public DateTime? Dt_Mvp { get; set; }

        //public int Id_Mvp1 { get; set; }
        //public int Id_Iniciativa1 { get; set; }
        //public string Nome_Mvp1 { get; set; }
        //public DateTime? Dt_Mvp1 { get; set; }

        //public int Id_Mvp2 { get; set; }
        //public int Id_Iniciativa2 { get; set; }
        //public string Nome_Mvp2 { get; set; }
        //public DateTime? Dt_Mvp2 { get; set; }


    }
}