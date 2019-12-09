using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Jornada_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

        public int InsereJornadaRetornaId(Jornada jornada, int? id_iniciativa)
        {
            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Jornada", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ux", jornada.UX);
                cmd.Parameters.AddWithValue("@jornada_analisada", jornada.varejo_acompanhou);
                cmd.Parameters.AddWithValue("@OPER", "I");


                return (int)cmd.ExecuteScalar();
            }
        }

        //public bool InsereOrcamento(Orcamento orcamento, int? id_iniciativa)
        //{


        //    if (orcamento.total_aprovado != null && orcamento.total_aprovado.Contains("."))
        //    {
        //        orcamento.total_aprovado.Replace(".", "");
        //    }
        //    if (orcamento.total_contratado != null && orcamento.total_contratado.Contains("."))
        //    {
        //        orcamento.total_contratado.Replace(".", "");
        //    }
        //    if (orcamento.total_realizado != null && orcamento.total_realizado.Contains("."))
        //    {
        //        orcamento.total_realizado.Replace(".", "");
        //    }
        //    //int id_orcamento = new int();

        //    var oper = orcamento.id_orcamento != null ? "U" : "I";
        //    var teste = Convert.ToDecimal(orcamento.total_aprovado);
        //    using (con)
        //    {
        //        var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Orcamento", con);
        //        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //        con.Open();

        //        cmd.Parameters.AddWithValue("@OPER", oper);
        //        cmd.Parameters.AddWithValue("@total_aprovado", Convert.ToDecimal(orcamento.total_aprovado));
        //        cmd.Parameters.AddWithValue("@total_realizado", Convert.ToDecimal(orcamento.total_realizado));
        //        cmd.Parameters.AddWithValue("@total_contratado", Convert.ToDecimal(orcamento.total_contratado));
        //        cmd.Parameters.AddWithValue("@id_orcamento", orcamento.id_orcamento);
        //        cmd.Parameters.AddWithValue("@id_iniciativa", id_iniciativa);
        //        cmd.ExecuteNonQuery();

        //        //var reader = cmd.ExecuteReader();

        //        //while (reader.Read())
        //        //{

        //        //    id_orcamento = Convert.ToInt32(reader["id_orcamento"]);

        //        //};

        //        return true;
        //        //return (int)cmd.ExecuteScalar();


        //    }
        //}
    }
}