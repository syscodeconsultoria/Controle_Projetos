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
    public class Departamento_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

        public List<Departamento> ListaDepartamentos()
        {
            List<Departamento> departamentos = new List<Departamento>();

            SqlCommand command = new SqlCommand("producao.UP_Controle_Projetos_Lista_Departamentos", con);
            command.CommandType = CommandType.StoredProcedure;

            con.Open();
            using (SqlDataReader sdr = command.ExecuteReader())
            {
                while (sdr.Read())
                {
                    departamentos.Add(new Departamento
                    {
                        Id_Departamento = Convert.ToInt32(sdr["id_departamento"]),
                        Cod_Departamento = Convert.ToInt32(sdr["cod_departamento"]),
                        Ds_Departamento = sdr["ds_departamento"].ToString()
                    });
                }
            }
            con.Close();

            return departamentos;
        }
    }
}