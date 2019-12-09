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
    public class Mega_DAL
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        public List<Mega> ListaMegas()
        {
            List<Mega> megas = new List<Mega>();

            SqlCommand command = new SqlCommand("producao.UP_Controle_Projetos_Lista_Megas", con);
            command.CommandType = CommandType.StoredProcedure;

            con.Open();
            using (SqlDataReader sdr = command.ExecuteReader())
            {
                while (sdr.Read())
                {
                    megas.Add(new Mega
                    {
                        Id_Mega = Convert.ToInt32(sdr["id_mega"]),
                        Ds_Mega = sdr["ds_mega"] as string                        
                    });
                }
            }
            con.Close();

            return megas;

        }

    }
}