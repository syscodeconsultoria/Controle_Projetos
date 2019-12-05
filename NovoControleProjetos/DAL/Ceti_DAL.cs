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
    public class Ceti_DAL
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        public int InsereCetiRetornaId(Ceti ceti, int? id_iniciativa)
        {
            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Ceti", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@total_aprovado_ceti", Convert.ToDecimal(ceti.Total_Aprovado_Ceti));
                if (ceti.Data_Ceti != null)
                {
                    cmd.Parameters.AddWithValue("@dt_CETI", ceti.Data_Ceti);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_CETI", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }

                return (int)cmd.ExecuteScalar();
            }
        }

        public Ceti BuscaCeti(int? id_iniciativa, int? id_ceti, string oper)
        {
            Ceti ceti = new Ceti();

            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Ceti", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", id_ceti);
                cmd.Parameters.AddWithValue("@OPER", oper);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ceti.Data_Ceti = reader["dt_CETI"] != DBNull.Value ? Convert.ToDateTime(reader["dt_CETI"]) : (DateTime?)null;
                    ceti.Total_Aprovado_Ceti = reader["tot_aprovado_ceti"] != null ? Convert.ToString(reader["tot_aprovado_ceti"]) : null;
                }
                return ceti;
            }

        }
    }
}