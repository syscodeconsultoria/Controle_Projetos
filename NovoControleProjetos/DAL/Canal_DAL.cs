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
    public class Canal_DAL
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        public List<Canal> ListaCanais()
        {
            List<Canal> canais = new List<Canal>();

            SqlCommand command = new SqlCommand("producao.UP_Controle_Projetos_Lista_Canais", con);
            command.CommandType = CommandType.StoredProcedure;

            con.Open();
            using (SqlDataReader sdr = command.ExecuteReader())
            {
                while (sdr.Read())
                {
                    canais.Add(new Canal
                    {
                        Id_Canal = Convert.ToInt32(sdr["id_canal"]),
                        Ds_Canal = sdr["ds_canal"] as string,
                        Ativo = Convert.ToBoolean(sdr["ativo"])
                    });
                }
            }
            con.Close();

            return canais;

        }
    }
}