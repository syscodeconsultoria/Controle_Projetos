using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Iniciativa_DAL
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

        public int RetornaIdIniciativa(string nome)
        {
            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Iniciativa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@nome_iniciativa", nome);
                cmd.Parameters.AddWithValue("@OPER", 1);
                

                return (int)cmd.ExecuteScalar();
            }
        }

        public Iniciativa GetIniciativa(int id)
        {
            var iniciativa = new Iniciativa();

            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Iniciativa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@OPER", 2);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    iniciativa.nome_iniciativa = reader["nome_iniciativa"] as string;
                    iniciativa.Id_Iniciativa = Convert.ToInt32(reader["Id_iniciativa"]);
                }


                return iniciativa;                                                                                                                                                                          
            }
        }

        public void UpdateIniciativa(Iniciativa iniciativa)
        {
            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Iniciativa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@OPER", 3);
                cmd.Parameters.AddWithValue("@ID", iniciativa.Id_Iniciativa);
                cmd.Parameters.AddWithValue("@nome_iniciativa", iniciativa.nome_iniciativa);
                cmd.Parameters.AddWithValue("@num_iniciativa", iniciativa.num_iniciativa);
                cmd.Parameters.AddWithValue("@id_departamento", iniciativa.id_departamento);
                //cmd.Parameters.AddWithValue("@esteira", iniciativa.Esteira);
                cmd.Parameters.AddWithValue("@id_esteira", iniciativa.id_esteira);
                cmd.Parameters.AddWithValue("@id_farol", iniciativa.id_farol);
                cmd.Parameters.AddWithValue("@id_etapa", iniciativa.id_etapa);
                cmd.Parameters.AddWithValue("@id_orcamento", iniciativa.id_orcamento);
                cmd.Parameters.AddWithValue("@CPF", iniciativa.CPF);
                //cmd.Parameters.AddWithValue("@VPL", iniciativa.VPL);
                //cmd.Parameters.AddWithValue("@id_CETI", iniciativa.id_CETI);
                //cmd.Parameters.AddWithValue("@id_comissao_varejo", iniciativa.id_comissao_varejo);
                //cmd.Parameters.AddWithValue("@id_jornada", iniciativa.id_jornada);
                cmd.Parameters.AddWithValue("@id_mega", iniciativa.id_mega);
                //cmd.Parameters.AddWithValue("@id_visita", iniciativa.id_visita);
                //cmd.Parameters.AddWithValue("@id_canal", iniciativa.id_canal);
                cmd.Parameters.AddWithValue("@TF_versao_agencia", iniciativa.TF_versao_agencia);
                cmd.Parameters.AddWithValue("@TF_versao_PA ", iniciativa.TF_versao_PA);
                //cmd.Parameters.AddWithValue("@id_origem", iniciativa.id_origem);
                //cmd.Parameters.AddWithValue("@id_dt", iniciativa.id_dt);
                //cmd.Parameters.AddWithValue("@id_replanejamento", iniciativa.id_replanejamento);
                cmd.Parameters.AddWithValue("@responsavel_neg", iniciativa.responsavel_neg);
                cmd.Parameters.AddWithValue("@responsavel_DS", iniciativa.responsavel_DS);
                cmd.Parameters.AddWithValue("@usabilidade", iniciativa.usabilidade);
                cmd.Parameters.AddWithValue("@beneficio_iniciativa", iniciativa.beneficio_iniciativa);

                cmd.ExecuteNonQuery();


            }
        }
    }
    
}