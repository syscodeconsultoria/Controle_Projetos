using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Mvp_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        /// <summary>
        /// Método para efetuar a entrada dos dados de MVP no banco de dados
        /// </summary>
        /// <param name="mvp"></param>
        /// <param name="Id_Iniciativa"></param>
        public void InsereMvpNoBanco(Mvp mvp, int Id_Iniciativa)
        {
            var cmd = new SqlCommand("UP_Controle_Projetos_Insert_MVP", con);

            using (con)
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id_iniciativa", Id_Iniciativa);

                cmd.Parameters.AddWithValue("@nome_mvp", mvp.Nome_Mvp);
                cmd.Parameters.AddWithValue("@opermvp", mvp.Id_Mvp > 0 ? "U" : "I");
                cmd.Parameters.AddWithValue("@id_mvp", mvp.Id_Mvp > 0 ? mvp.Id_Mvp : (int?)null);

                cmd.Parameters.AddWithValue("@nome_mvp1", mvp.Nome_Mvp1);
                cmd.Parameters.AddWithValue("@opermvp1", mvp.Id_Mvp1 > 0 ? "U" : "I");
                cmd.Parameters.AddWithValue("@id_mvp1", mvp.Id_Mvp1 > 0 ? mvp.Id_Mvp1 : (int?)null);

                cmd.Parameters.AddWithValue("@nome_mvp2", mvp.Nome_Mvp2);
                cmd.Parameters.AddWithValue("@opermvp2", mvp.Id_Mvp2 > 0 ? "U" : "I" );
                cmd.Parameters.AddWithValue("@id_mvp2", mvp.Id_Mvp2 > 0 ? mvp.Id_Mvp1 : (int?)null);

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
                    cmd.Parameters.AddWithValue("@dt_mvp2", mvp.Dt_Mvp2);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_mvp2", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }
                cmd.Parameters.AddWithValue("@tipo_operacao", 1);

                cmd.ExecuteNonQuery();
            }

        }
        /// <summary>
        /// Método para efetuar a busca dos dados de MVP dentro do banco de dados será necessário criar uma variavel para efetuar
        /// a contagem de voltas do loop sendo que para cada volta acrescentar os dados em uma variavel diferente
        /// </summary>
        /// <param name="IdIniciativa"></param>
        /// <returns></returns>
        public Mvp MvpsBuscaNoBanco(int IdIniciativa)
        {
            int i = 0;
            var cmd = new SqlCommand("UP_Controle_Projetos_Insert_MVP", con);
            Mvp mvps = new Mvp();
            using (con)
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@tipo_operacao", 2);
                cmd.Parameters.AddWithValue("@id_iniciativa", IdIniciativa);

                var data = cmd.ExecuteReader();

                    while (data.Read())
                    {
                        switch (i)
                        {
                            case 0:
                                {
                                    mvps.Id_Mvp = int.Parse(data["id_MVP"].ToString());
                                    mvps.Nome_Mvp = data["nome_mvp"].ToString();
                                    mvps.Id_Iniciativa = int.Parse(data["id_iniciativa"].ToString());
                                    mvps.Dt_Mvp = DateTime.Parse(data["dt_mvp"].ToString());
                                }
                                break;
                            case 1:
                                {
                                    mvps.Id_Mvp1 = int.Parse(data["id_MVP"].ToString());
                                    mvps.Nome_Mvp1 = data["nome_mvp"].ToString();
                                    mvps.Id_Iniciativa1 = int.Parse(data["id_iniciativa"].ToString());
                                    mvps.Dt_Mvp1 = DateTime.Parse(data["dt_mvp"].ToString());
                                }
                                break;
                            case 2:
                                {
                                    mvps.Id_Mvp2 = int.Parse(data["id_MVP"].ToString());
                                    mvps.Nome_Mvp2 = data["nome_mvp"].ToString();
                                    mvps.Id_Iniciativa2 = int.Parse(data["id_iniciativa"].ToString());
                                    mvps.Dt_Mvp2 = DateTime.Parse(data["dt_mvp"].ToString());
                                }
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                    return mvps;
            }
        }
    }
}