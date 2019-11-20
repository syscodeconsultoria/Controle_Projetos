using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Origem_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        public List<Origem> ListaOrigens()
        {
            List<Origem> origens = new List<Origem>();

            SqlCommand command = new SqlCommand("producao.UP_Controle_Projetos_Lista_Origens", con);
            command.CommandType = CommandType.StoredProcedure;

            con.Open();
            using (SqlDataReader sdr = command.ExecuteReader())
            {
                while (sdr.Read())
                {
                    origens.Add(new Origem
                    {
                        Id_Origem = Convert.ToInt32(sdr["id_origem"]),
                        Ds_Origem = sdr["ds_origem"] as string
                    });
                }
            }
            con.Close();

            return origens;

        }
    }
}