using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Iniciativa
    {
        public int Id_Iniciativa { get; set; }
        public string nome_iniciativa { get; set; }
        public int? num_iniciativa { get; set; }
        public int? id_departamento { get; set; }
        public DateTime? data_aprovacao { get; set; }
        public DateTime? data_piloto { get; set; }
        public DateTime? data_plenouso { get; set; }

        public DateTime? data_comunicacao { get; set; }
        public int? id_esteira { get; set; }
        public int? id_farol { get; set; }
        public string cor_farol { get; set; }
        public string ds_farol { get; set; }
        public int? id_etapa { get; set; }
        public string CPF { get; set; }
        public int? id_mega { get; set; }
        public string TF_versao_agencia { get; set; }
        public string TF_versao_PA { get; set; }
        public string responsavel_neg { get; set; }
        public string responsavel_DS { get; set; }
        public string resumo_iniciativa { get; set; }
        public bool? usabilidade { get; set; }
        public string beneficio_iniciativa { get; set; }
        public Orcamento orcamento { get; set; }
        public Ceti ceti { get; set; }
        public List<int> idsOrigens { get; set; }
        public int? id_orcamento { get; set; }
        //public decimal VPL { get; set; }
        public Jornada jornada { get; set; }
        public int id_jornada { get; set; }
        public int? id_ceti { get; set; }
        public int? id_replanejamento { get; set; }
        public int? id_visita { get; set; }
        public Replanejamento replanejamento { get; set; }

        public Visita visita { get; set; }
        //public Farol farol  { get  { return new Farol(); } set {  }
          
        //}

        public Farol farol { get; set; }

    }
}