using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Mvp_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        
        public void InsereMvpNoBanco(Mvp mvp, int Id_Iniciativa)
        {
            var cmd = new SqlCommand("UP_Controle_Projetos_Insert_MVP", con);

            using (con)
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@nome_mvp", mvp.Nome_Mvp);
                cmd.Parameters.AddWithValue("@id_iniciativa", Id_Iniciativa);

                if (mvp.Dt_Mvp.Ticks != 0)
                {
                    cmd.Parameters.AddWithValue("@dt_mvp", mvp.Dt_Mvp);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_mvp", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }

                
                if (mvp.Dt_Mvp1.Ticks != 0)
                {
                    cmd.Parameters.AddWithValue("@dt_mvp1", mvp.Dt_Mvp1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_mvp1", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }

             
                if (mvp.Dt_Mvp2.Ticks != 0)
                {
                    cmd.Parameters.AddWithValue("@dt_mvp2", mvp.Dt_Mvp);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_mvp2", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }
                cmd.Parameters.AddWithValue("@tipo_operacao", 1);

                cmd.ExecuteNonQuery();
            }

        }
    }
}