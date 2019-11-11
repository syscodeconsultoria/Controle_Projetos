using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.Models
{
    public class Iniciativa
    {
        public string Nome_Iniciativa { get; set; }
        public int cod_departamento { get; set; }
        public string Esteira { get; set; }
        public int cod_farol { get; set; }
        public int cod_etapa { get; set; }
        public string CPF { get; set; }
        public decimal VPL { get; set; }
        public int cod_orcamento { get; set; }
        public int cod_CETI { get; set; }
        public int cod_comissao_varejo { get; set; }
        public int cod_jornada { get; set; }
        public int cod_mega { get; set; }
        public int cod_visita { get; set; }
        public int cod_canal { get; set; }
        public string TF_versao_agencia { get; set; }
        public string TF_versao_PA { get; set; }
        public int cod_prioritario { get; set; }
        public int cod_dt { get; set; }
        public int cod_replanejamento { get; set; }
        public string responsavel_neg { get; set; }
        public string responsavel_DS { get; set; }
        public string resumo_iniciativa { get; set; }

    }
}