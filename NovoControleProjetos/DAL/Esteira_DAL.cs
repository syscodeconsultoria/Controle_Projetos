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
    public class Esteira_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

        public List<Esteira> ListaEsteira()
        {
            List<Esteira> esteiras = new List<Esteira>();

            SqlCommand command = new SqlCommand("producao.UP_Controle_Projetos_Lista_Esteiras", con);
            command.CommandType = CommandType.StoredProcedure;

            con.Open();
            using (SqlDataReader sdr = command.ExecuteReader())
            {
                while (sdr.Read())
                {
                    esteiras.Add(new Esteira
                    {
                        Id_Esteira = Convert.ToInt32(sdr["cod_esteira"]),
                        Ds_Esteira = sdr["ds_esteira"] as string                        
                    });
                }
            }
            con.Close();

            return esteiras;
        }
    }
}