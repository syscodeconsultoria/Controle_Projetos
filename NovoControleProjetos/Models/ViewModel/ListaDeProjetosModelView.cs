using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models.ViewModel
{
    public class ListaDeProjetosModelView
    {
        [Display(Name ="Inicitiva")]
        public int IdIniciativa { get; set; }

        [Display(Name ="Nome do projeto")]
        public string NomeIniciativa { get; set; }

        [Display(Name ="Nome do departamento")]
        public string NomeDepartamento { get; set; }

        [Display(Name ="Data de aprovação")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DtAprovacao { get; set; }
    }
}