using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Orcamento_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

        public int InsereOrcamentoRetornaId(Orcamento orcamento)
        {
            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Orcamento", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@total_aprovado", orcamento.total_aprovado);
                cmd.Parameters.AddWithValue("@total_realizado", orcamento.total_realizado);
                cmd.Parameters.AddWithValue("@total_contratado", orcamento.total_contratado);
                cmd.Parameters.AddWithValue("@OPER", "I");


                return (int)cmd.ExecuteScalar();
            }
        }

        public int InsereOrcamento(Orcamento orcamento, int? id_iniciativa)
        {
            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Orcamento", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@OPER", "I");
                cmd.Parameters.AddWithValue("@total_aprovado", orcamento.total_aprovado);
                cmd.Parameters.AddWithValue("@total_realizado", orcamento.total_realizado);
                cmd.Parameters.AddWithValue("@total_contratado", orcamento.total_contratado);
                cmd.Parameters.AddWithValue("@id_iniciativa", id_iniciativa);

                return (int)cmd.ExecuteScalar();
            }
        }
    }
}