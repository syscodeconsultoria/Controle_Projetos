using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Iniciativa_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

        public int RetornaIdIniciativa(string nome)
        {
            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Iniciativa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@INICIATIVA", nome);
                cmd.Parameters.AddWithValue("@OPER", 1);
                

                return (int)cmd.ExecuteScalar();
            }
        }

        public Iniciativa GetIniciativa(int id)
        {
            var iniciativa = new Iniciativa();

            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Iniciativa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@OPER", 2);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    iniciativa.Nome_Iniciativa = reader["nome_iniciativa"] as string;
                }


                return iniciativa;                                                                                                                                                                          
            }
        }
    }
}