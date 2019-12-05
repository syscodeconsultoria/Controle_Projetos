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
    public class Vertical_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        public List<Vertical> ListaVerticais()
        {
            List<Vertical> verticais = new List<Vertical>();

            SqlCommand command = new SqlCommand("producao.UP_Controle_Projetos_Lista_Verticais", con);
            command.CommandType = CommandType.StoredProcedure;

            con.Open();
            using (SqlDataReader sdr = command.ExecuteReader())
            {
                while (sdr.Read())
                {
                    verticais.Add(new Vertical
                    {
                        Id_Vertical = Convert.ToInt32(sdr["id_vertical"]),
                        Ds_Vertical = sdr["ds_vertical"] as string
                    });
                }
            }
            con.Close();

            return verticais;

        }
    }
}