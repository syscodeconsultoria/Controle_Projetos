using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Farol_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

        public List<Farol> _ListaFarol()
        {
            var farois = new List<Farol>();
            var cmd = new SqlCommand("producao.UP_Controle_Projetos_Lista_Farois", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                farois.Add(new Farol
                {
                    IdFarol = Convert.ToInt32(reader["id_farol"]),
                    Ds_Farol = reader["ds_farol"] as string,
                    Cor_Farol = reader["cor_farol"] as string
                });
            }
            reader.Close();
            con.Close();
            return farois;
        }
    }
}