using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Visita_DAL
    {

        public Visita BuscaVisita(int? id_visita, int? id_iniciativa)
        {

            Visita visita = new Visita();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Visita", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                //cmd.Parameters.AddWithValue("@id_iniciativa", id_iniciativa);
                cmd.Parameters.AddWithValue("@id_visita", id_visita);                
                cmd.Parameters.AddWithValue("@OPER", "S");

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    visita.Cod_Agencia = reader["cod_agencia"] != DBNull.Value ? Convert.ToInt32(reader["cod_agencia"]) : (int?)null;
                    visita.Data_Visita = reader["dt_visita"] != DBNull.Value ? Convert.ToDateTime(reader["dt_visita"]) : (DateTime?)null;
                    visita.Nome_Agencia = reader["nome_agencia"] as string;
                }
                return visita;
            }



        }

        public int InsereVisita(Visita visita, int? id_iniciativa, int? id_visita, string oper)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
            //int id_orcamento = new int();

            var _oper = oper;

            using (con)
            {

                try
                {
                    var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Visita", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@OPER", _oper);
                    cmd.Parameters.AddWithValue("@id_iniciativa", id_iniciativa);
                    cmd.Parameters.AddWithValue("@cod_agencia", visita.Cod_Agencia);
                    cmd.Parameters.AddWithValue("@nome_agencia", visita.Nome_Agencia);
                    cmd.Parameters.AddWithValue("@dt_visita", visita.Data_Visita);


                    if (oper == "U")
                    {
                        cmd.ExecuteNonQuery();

                        return (int)id_visita;
                    }
                    else
                    {
                        return (int)cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    return 0;
                }

               

            }
        }

    }
}