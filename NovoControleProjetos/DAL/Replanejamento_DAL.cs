using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Replanejamento_DAL
    {

        public int InsereReplanejamentoRetornaId(Replanejamento replanejamento, int? id_iniciativa, int? id_replanejamento, string oper)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

            using (con)
            {

               
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Replanejamento", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                if (id_replanejamento != null && id_replanejamento > 0)
                {
                    cmd.Parameters.AddWithValue("@id_replanejamento", id_replanejamento);
                }
                cmd.Parameters.AddWithValue("@OPER", oper);
                cmd.Parameters.AddWithValue("@motivo_replanejamento", replanejamento.motivo_replanejamento);


                if (replanejamento.data_replanejamento != null)
                {
                    cmd.Parameters.AddWithValue("@dt_replanejamento", replanejamento.data_replanejamento);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_replanejamento", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }

                if (oper == "U")
                {
                    cmd.ExecuteNonQuery();

                    return (int)id_replanejamento;
                }
                else
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public Replanejamento BuscaReplanejamento(int? id_replanejamento, int? id_iniciativa, string oper)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

            Replanejamento replanejamento = new Replanejamento();

            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Replanejamento", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id_replanejamento", id_replanejamento);
                cmd.Parameters.AddWithValue("@OPER", "S");

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    replanejamento.id_replanejamento = reader["id_replanejamento"] != DBNull.Value ? Convert.ToInt32(reader["id_replanejamento"]) : (int?)null; 
                    replanejamento.motivo_replanejamento = reader["motivo_replanejamento"] != DBNull.Value ? reader["motivo_replanejamento"] as string : null;
                    replanejamento.data_replanejamento = reader["dt_replanejamento"] != DBNull.Value ? Convert.ToDateTime(reader["dt_replanejamento"]) : (DateTime?)null;
                }
                return replanejamento;
            }

        }
    }
}
