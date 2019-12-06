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

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        public int InsereCetiRetornaId(Ceti ceti, int? id_iniciativa, int? id_ceti, string oper)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

            using (con)
            {

                if (ceti.Total_Aprovado_Ceti != null && ceti.Total_Aprovado_Ceti.Contains("."))
                {
                    ceti.Total_Aprovado_Ceti.Replace(".", "");
                }

                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Ceti", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                if(id_ceti != null)
                {
                    cmd.Parameters.AddWithValue("@id_CETI", id_ceti);
                }
                cmd.Parameters.AddWithValue("@OPER", oper);
                cmd.Parameters.AddWithValue("@total_aprovado_ceti", Convert.ToDecimal(ceti.Total_Aprovado_Ceti));
                

                if (ceti.Data_Ceti != null)
                {
                    cmd.Parameters.AddWithValue("@dt_CETI", ceti.Data_Ceti);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_CETI", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }

                if (oper == "U")
                {
                    cmd.ExecuteNonQuery();

                    return (int)id_ceti;
                }
                else
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public Ceti BuscaCeti(int? id_ceti, int? id_iniciativa, string oper)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

            Ceti ceti = new Ceti();

            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Ceti", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id_CETI", id_ceti);
                cmd.Parameters.AddWithValue("@OPER", "S");

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