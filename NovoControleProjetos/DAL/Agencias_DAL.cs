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
    public class Agencias_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

        public List<Agencias> ListaEsteira()
        {
            List<Agencias> agencias = new List<Agencias>();

            SqlCommand command = new SqlCommand("producao.UP_Controle_Projetos_Lista_Agencias", con);
            command.CommandType = CommandType.StoredProcedure;

            con.Open();
            using (SqlDataReader sdr = command.ExecuteReader())
            {
                while (sdr.Read())
                {
                    agencias.Add(new Agencias
                    {
                        id_agencia = Convert.ToInt32(sdr["CODAGENCIA"]),
                        nome_agencia = sdr["NOMEAGENCIA"] as string
                    });
                }
            }
            con.Close();

            return agencias;
        }
    }
}