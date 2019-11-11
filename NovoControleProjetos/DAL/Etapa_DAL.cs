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
    public class Etapa_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        public List<Etapa> ListaEsteira()
        {
            List<Etapa> etapas = new List<Etapa>();

            SqlCommand command = new SqlCommand("producao.UP_Controle_Projetos_Lista_Etapas", con);
            command.CommandType = CommandType.StoredProcedure;

            con.Open();
            using (SqlDataReader sdr = command.ExecuteReader())
            {
                while (sdr.Read())
                {
                    etapas.Add(new Etapa
                    {
                        Id_Etapa = Convert.ToInt32(sdr["cod_etapa"]),
                        Ds_Etapa = sdr["ds_etapa"] as string
                    });
                }
            }
            con.Close();

            return etapas;

        }
    }
}