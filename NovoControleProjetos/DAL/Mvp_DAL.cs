﻿using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;

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
        public void InsereMvpNoBanco(List<Mvp> mvp)
        {
            var cmd = new SqlCommand("UP_Controle_Projetos_Oper_M_MVP", con);

            using (con)
            {
                try
                {
                    
                    con.Open();
                    foreach (Mvp item in mvp)
                    {                        
                        cmd.Parameters.Clear();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_iniciativa", item.Id_Iniciativa);

                        cmd.Parameters.AddWithValue("@nome_mvp", item.Nome_Mvp);
                        cmd.Parameters.AddWithValue("@id_mvp", item.Id_Mvp > 0 ? item.Id_Mvp : 0);

                        if (item.Dt_Mvp != null)
                        {
                            cmd.Parameters.AddWithValue("@dt_mvp", item.Dt_Mvp);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@dt_mvp", SqlDbType.DateTime).Value = SqlDateTime.Null;
                        }
                        cmd.Parameters.AddWithValue("@tipo_operacao", 1);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {

                }

            }
        }

        //cmd.Parameters.AddWithValue("@nome_mvp1", mvp.Nome_Mvp1);
        //cmd.Parameters.AddWithValue("@opermvp1", mvp.Id_Mvp1 > 0 ? "U" : "I");
        //cmd.Parameters.AddWithValue("@id_mvp1", mvp.Id_Mvp1 > 0 ? mvp.Id_Mvp1 : 0);

        //cmd.Parameters.AddWithValue("@nome_mvp2", mvp.Nome_Mvp2);
        //cmd.Parameters.AddWithValue("@opermvp2", mvp.Id_Mvp2 > 0 ? "U" : "I" );
        //cmd.Parameters.AddWithValue("@id_mvp2", mvp.Id_Mvp2 > 0 ? mvp.Id_Mvp2 : 0);



        //if (mvp.Dt_Mvp1 != null)
        //{
        //    cmd.Parameters.AddWithValue("@dt_mvp1", mvp.Dt_Mvp1);
        //}
        //else
        //{
        //    cmd.Parameters.AddWithValue("@dt_mvp1", SqlDbType.DateTime).Value = SqlDateTime.Null;
        //}

        //if (mvp.Dt_Mvp2 != null)
        //{
        //    cmd.Parameters.AddWithValue("@dt_mvp2", mvp.Dt_Mvp2);
        //}
        //else
        //{
        //    cmd.Parameters.AddWithValue("@dt_mvp2", SqlDbType.DateTime).Value = SqlDateTime.Null;
        //}

        /// <summary>
        /// Método para efetuar a busca dos dados de MVP dentro do banco de dados será necessário criar uma variavel para efetuar
        /// a contagem de voltas do loop sendo que para cada volta acrescentar os dados em uma variavel diferente
        /// </summary>
        /// <param name="IdIniciativa"></param>
        /// <returns></returns>
        public List<Mvp> MvpsBuscaNoBanco(int IdIniciativa)
        {
            var cmd = new SqlCommand("UP_Controle_Projetos_Oper_M_MVP", con);
            var mvps = new List<Mvp>();
            using (con)
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();

                cmd.Parameters.AddWithValue("@tipo_operacao", 2);
                cmd.Parameters.AddWithValue("@id_iniciativa", IdIniciativa);

                var data = cmd.ExecuteReader();

                while (data.Read())
                {

                    mvps.Add(new Mvp
                    {
                        Dt_Mvp = data["dt_mvp"] != DBNull.Value ? DateTime.Parse(data["dt_mvp"].ToString()) : (DateTime?)(null),
                        Id_Iniciativa = int.Parse(data["id_iniciativa"].ToString()),
                        Id_Mvp = int.Parse(data["id_MVP"].ToString()),
                        Nome_Mvp = data["nome_mvp"].ToString()
                    });
                }
                return mvps;
                //switch (i)
                //{
                //case 0:
                //    {
                //        mvps.Id_Mvp = int.Parse(data["id_MVP"].ToString());
                //        mvps.Nome_Mvp = data["nome_mvp"].ToString();
                //        mvps.Id_Iniciativa = int.Parse(data["id_iniciativa"].ToString());
                //        mvps.Dt_Mvp = data["dt_mvp"] != DBNull.Value ? DateTime.Parse(data["dt_mvp"].ToString()) : (DateTime?)(null);
                //    }
                //    break;
                //case 1:
                //    {
                //        mvps.Id_Mvp1 = int.Parse(data["id_MVP"].ToString());
                //        mvps.Nome_Mvp1 = data["nome_mvp"].ToString();
                //        mvps.Id_Iniciativa1 = int.Parse(data["id_iniciativa"].ToString());
                //        mvps.Dt_Mvp1 = data["dt_mvp"] != DBNull.Value ? DateTime.Parse(data["dt_mvp"].ToString()) : (DateTime?)(null);
                //    }
                //    break;
                //case 2:
                //    {
                //        mvps.Id_Mvp2 = int.Parse(data["id_MVP"].ToString());
                //        mvps.Nome_Mvp2 = data["nome_mvp"].ToString();
                //        mvps.Id_Iniciativa2 = int.Parse(data["id_iniciativa"].ToString());
                //        mvps.Dt_Mvp2 = data["dt_mvp"] != DBNull.Value ? DateTime.Parse(data["dt_mvp"].ToString()) : (DateTime?)(null);
                //    }
                //    break;
                //default:
                //    break;
                //}
                //i++;

            }
        }
    }
}