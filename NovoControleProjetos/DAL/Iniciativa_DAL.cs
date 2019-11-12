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
                    iniciativa.Nome_Iniciativa = reader["nome_iniciativa"] as string;
                    iniciativa.Id_Iniciativa = Convert.ToInt32(reader["Id_iniciativa"]);
                }


                return iniciativa;                                                                                                                                                                          
            }
        }

        public void UpdateIniciativa(Iniciativa model)
        {
            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Iniciativa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@OPER", 3);
                cmd.Parameters.AddWithValue("@ID", model.Id_Iniciativa);
                cmd.Parameters.AddWithValue("@INICIATIVA", model.Nome_Iniciativa);
                cmd.Parameters.AddWithValue("@num_iniciativa", model.Num_Iniciativa);
                cmd.Parameters.AddWithValue("@cod_departamento", model.cod_departamento);
                cmd.Parameters.AddWithValue("@esteira", model.Esteira);
                cmd.Parameters.AddWithValue("@cod_farol", model.cod_farol);
                cmd.Parameters.AddWithValue("@cod_etapa", model.cod_etapa);
                cmd.Parameters.AddWithValue("@cod_orcamento", model.cod_orcamento);
                cmd.Parameters.AddWithValue("@CPF", model.CPF);
                cmd.Parameters.AddWithValue("@VPL", model.VPL);
                cmd.Parameters.AddWithValue("@cod_CETI", model.cod_CETI);
                cmd.Parameters.AddWithValue("@cod_comissao_varejo", model.cod_comissao_varejo);
                cmd.Parameters.AddWithValue("@cod_jornada", model.cod_jornada);
                cmd.Parameters.AddWithValue("@cod_mega", model.cod_mega);
                cmd.Parameters.AddWithValue("@cod_visita", model.cod_visita);
                cmd.Parameters.AddWithValue("@cod_canal", model.cod_canal);
                cmd.Parameters.AddWithValue("@TF_versao_agencia", model.TF_versao_agencia);
                cmd.Parameters.AddWithValue("@TF_versao_PA ", model.TF_versao_PA);
                cmd.Parameters.AddWithValue("@cod_prioritario", model.cod_prioritario);
                cmd.Parameters.AddWithValue("@cod_dt", model.cod_dt);
                cmd.Parameters.AddWithValue("@cod_replanejamento", model.cod_replanejamento);
                cmd.Parameters.AddWithValue("@responsavel_neg", model.responsavel_neg);
                cmd.Parameters.AddWithValue("@responsavel_DS", model.responsavel_DS);
                cmd.Parameters.AddWithValue("@resumo_iniciativa", model.resumo_iniciativa);

                cmd.ExecuteNonQuery();


            }
        }
    }
    
}