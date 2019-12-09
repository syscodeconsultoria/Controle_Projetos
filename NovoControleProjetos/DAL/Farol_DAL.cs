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

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

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

        public bool InsereComentarioFarol(Farol farol, int? id_iniciativa, int? id_farol, int? id_comentario_farol, string oper)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
            //int id_orcamento = new int();

            var _oper = oper;
            
            using (con)
            {

                try
                {
                    var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Farol", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();

                    cmd.Parameters.AddWithValue("@OPER", _oper);
                    cmd.Parameters.AddWithValue("@comentario_farol", farol.Comentario_Farol);
                    cmd.Parameters.AddWithValue("@id_iniciativa", id_iniciativa);
                    cmd.Parameters.AddWithValue("@id_farol", id_farol != null ? id_farol : null);
                    cmd.Parameters.AddWithValue("@id_comentario_farol", id_comentario_farol != null ? id_comentario_farol : null);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {

                   return false;
                }             
           
                return true;             
                
            }
        }

        public Farol BuscaFarolComentario(int? id_iniciativa, int? id_farol, int? id_comentario_farol)
        {

            Farol farol = new Farol();

            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Farol", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@id_iniciativa", id_iniciativa);
                cmd.Parameters.AddWithValue("@id_farol", id_farol);
                cmd.Parameters.AddWithValue("@id_comentario_farol", id_comentario_farol != null ? id_comentario_farol : null);
                cmd.Parameters.AddWithValue("@OPER", "S");

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    farol.Comentario_Farol = reader["comentario_farol"] as string;  
                    farol.Id_Comentario_Farol = reader["id_comentario_Farol"] != DBNull.Value ? Convert.ToInt32(reader["id_comentario_farol"]) : (int?)null;
                }
                return farol;
            }


       
        }
    }
}