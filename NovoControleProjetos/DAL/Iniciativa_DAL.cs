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
                cmd.Parameters.AddWithValue("@INICIATIVA", nome);
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
                cmd.Parameters.AddWithValue("@INICIATIVA", iniciativa.nome_iniciativa);
                cmd.Parameters.AddWithValue("@num_iniciativa", iniciativa.num_iniciativa);
                cmd.Parameters.AddWithValue("@cod_departamento", iniciativa.cod_departamento);
                cmd.Parameters.AddWithValue("@esteira", iniciativa.Esteira);
                cmd.Parameters.AddWithValue("@cod_farol", iniciativa.cod_farol);
                cmd.Parameters.AddWithValue("@cod_etapa", iniciativa.cod_etapa);
                cmd.Parameters.AddWithValue("@cod_orcamento", iniciativa.cod_orcamento);
                cmd.Parameters.AddWithValue("@CPF", iniciativa.CPF);
                cmd.Parameters.AddWithValue("@VPL", iniciativa.VPL);
                cmd.Parameters.AddWithValue("@cod_CETI", iniciativa.cod_CETI);
                cmd.Parameters.AddWithValue("@cod_comissao_varejo", iniciativa.cod_comissao_varejo);
                cmd.Parameters.AddWithValue("@cod_jornada", iniciativa.cod_jornada);
                cmd.Parameters.AddWithValue("@cod_mega", iniciativa.cod_mega);
                cmd.Parameters.AddWithValue("@cod_visita", iniciativa.cod_visita);
                cmd.Parameters.AddWithValue("@cod_canal", iniciativa.cod_canal);
                cmd.Parameters.AddWithValue("@TF_versao_agencia", iniciativa.TF_versao_agencia);
                cmd.Parameters.AddWithValue("@TF_versao_PA ", iniciativa.TF_versao_PA);
                cmd.Parameters.AddWithValue("@cod_prioritario", iniciativa.cod_prioritario);
                cmd.Parameters.AddWithValue("@cod_dt", iniciativa.cod_dt);
                cmd.Parameters.AddWithValue("@cod_replanejamento", iniciativa.cod_replanejamento);
                cmd.Parameters.AddWithValue("@responsavel_neg", iniciativa.responsavel_neg);
                cmd.Parameters.AddWithValue("@responsavel_DS", iniciativa.responsavel_DS);
                cmd.Parameters.AddWithValue("@resumo_iniciativa", iniciativa.resumo_iniciativa);

                cmd.ExecuteNonQuery();


            }
        }
    }
    
}