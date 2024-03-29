﻿using NovoControleProjetos.Models;
using NovoControleProjetos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;
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

        public Iniciativa Buscainiciativa(int? id)
        {
            Iniciativa iniciativa = new Iniciativa();

            using (con)
            {
                var idsOrigs = new List<Origem>();
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Iniciativa", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@OPER", 4);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    iniciativa.nome_iniciativa = reader["nome_iniciativa"] as string;
                    iniciativa.Id_Iniciativa = Convert.ToInt32(reader["Id_iniciativa"]);
                    iniciativa.CPF = reader["CPF"] as string;
                    iniciativa.num_iniciativa = reader["num_iniciativa"] != DBNull.Value ? Convert.ToInt32(reader["num_iniciativa"]) : (int?)null;
                    iniciativa.responsavel_DS = reader["responsavel_ds"] as string;
                    iniciativa.responsavel_neg = reader["responsavel_neg"] as string;
                    iniciativa.TF_versao_agencia = reader["tf_versao_agencia"] as string;
                    iniciativa.TF_versao_PA = reader["tf_versao_pa"] as string;
                    iniciativa.resumo_iniciativa = reader["resumo_iniciativa"] as string;
                    iniciativa.beneficio_iniciativa = reader["beneficio_iniciativa"] as string;
                    iniciativa.id_ceti = reader["id_CETI"] != DBNull.Value ? Convert.ToInt32(reader["id_CETI"]) : (int?)null;
                    iniciativa.id_departamento = reader["id_departamento"] != DBNull.Value ? Convert.ToInt32(reader["id_departamento"]) : (int?)null;

                    iniciativa.data_aprovacao = reader["dt_aprovacao"] != DBNull.Value ? Convert.ToDateTime(reader["dt_aprovacao"]) : (DateTime?)null;
                    iniciativa.data_piloto = reader["dt_piloto"] != DBNull.Value ? Convert.ToDateTime(reader["dt_piloto"]) : (DateTime?)null;
                    iniciativa.data_plenouso = reader["dt_plenouso"] != DBNull.Value ? Convert.ToDateTime(reader["dt_plenouso"]) : (DateTime?)null;
                    iniciativa.id_esteira = reader["id_esteira"] != DBNull.Value ? Convert.ToInt32(reader["id_esteira"]) : (int?)null;
                    iniciativa.id_etapa = reader["id_etapa"] != DBNull.Value ? Convert.ToInt32(reader["id_etapa"]) : (int?)null;
                    iniciativa.id_farol = reader["id_farol"] != DBNull.Value ? Convert.ToInt32(reader["id_farol"]) : (int?)null;
                    iniciativa.id_mega = reader["id_mega"] != DBNull.Value ? Convert.ToInt32(reader["id_mega"]) : (int?)null;
                    iniciativa.cor_farol = reader["cor_farol"] as string;
                    iniciativa.ds_farol = reader["ds_farol"] as string;
                    iniciativa.data_comunicacao = reader["dt_comunicacao"] != DBNull.Value ? Convert.ToDateTime(reader["dt_comunicacao"]) : (DateTime?)null;
                    iniciativa.usabilidade = reader["usabilidade"] != DBNull.Value ? Convert.ToBoolean(reader["usabilidade"]) : (bool?)null;
                    iniciativa.id_replanejamento = reader["id_replanejamento"] != DBNull.Value ? Convert.ToInt32(reader["id_replanejamento"]) : (int?)null;
                    iniciativa.id_visita = reader["id_visita"] != DBNull.Value ? Convert.ToInt32(reader["id_visita"]) : (int?)null;


                    //iniciativa.usabilidade = Convert.ToBoolean(reader["usabilidade"]);
                    iniciativa.orcamento = new Orcamento
                    {
                        id_orcamento = reader["id_orcamento"] != DBNull.Value ? Convert.ToInt32(reader["id_orcamento"]) : (int?)null,
                        total_aprovado = reader["tot_aprovado"] != null ? Convert.ToString(reader["tot_aprovado"]) : null,
                        total_contratado = reader["tot_contratado"] != null ? Convert.ToString(reader["tot_contratado"]) : null,
                        total_realizado = reader["tot_realizado"] != null ? Convert.ToString(reader["tot_realizado"]) : null,

                    };

                    iniciativa.ceti = new Ceti
                    {
                        id_CETI = reader["id_CETI"] != DBNull.Value ? Convert.ToInt32(reader["id_CETI"]) : (int?)null,
                        Total_Aprovado_Ceti = reader["tot_aprovado_ceti"] != null ? Convert.ToString(reader["tot_aprovado_ceti"]) : null,
                        Data_Ceti = reader["dt_CETI"] != DBNull.Value ? Convert.ToDateTime(reader["dt_CETI"]) : (DateTime?)null,

                    };

                    iniciativa.jornada = new Jornada
                    {
                        id_jornada = reader["id_jornada"] != DBNull.Value ? Convert.ToInt32(reader["id_jornada"]) : (int?)null,
                        UX = reader["ux"] != DBNull.Value ? Convert.ToBoolean(reader["ux"]) : (bool?)null,
                        varejo_acompanhou = reader["varejo_acompanhou"] != DBNull.Value ? Convert.ToBoolean(reader["varejo_acompanhou"]) : (bool?)null,
                    };

                    iniciativa.replanejamento = new Replanejamento
                    {
                        id_replanejamento = reader["id_replanejamento"] != DBNull.Value ? Convert.ToInt32(reader["id_replanejamento"]) : (int?)null,
                        motivo_replanejamento = reader["motivo_replanejamento"] as string,
                        data_replanejamento = reader["dt_replanejamento"] != DBNull.Value ? Convert.ToDateTime(reader["dt_replanejamento"]) : (DateTime?)null,
                    };

                    iniciativa.farol = new Farol
                    {
                        Comentario_Farol = reader["comentario_farol"] as string,
                        Id_Comentario_Farol = reader["id_comentario_farol"] != DBNull.Value ? Convert.ToInt32(reader["id_comentario_farol"]) : (int?)null,
                        Data_Comentario = reader["dt_comentario"] != DBNull.Value ? Convert.ToDateTime(reader["dt_comentario"]) : (DateTime?)null,

                    };

                    iniciativa.visita = new Visita
                    {
                        Id_Visita = reader["id_visita"] != DBNull.Value ? Convert.ToInt32(reader["id_visita"]) : (int?)null,
                        Cod_Agencia = reader["cod_agencia"] != DBNull.Value ? Convert.ToInt32(reader["cod_agencia"]) : (int?)null,
                        Data_Visita = reader["dt_visita"] != DBNull.Value ? Convert.ToDateTime(reader["dt_visita"]) : (DateTime?)null,
                        Nome_Agencia = reader["nome_agencia"] as string,
                    };


                    //iniciativa.idsOrigens = new List<int>();

                    //if (!idsOrigs.Exists(i => i.Id_Origem.ToString().Equals(reader["id_origem"])))
                    //{
                    //    idsOrigs.Add(new Origem
                    //    {
                    //        Id_Origem = Convert.ToInt32(reader["id_origem"])
                    //    });

                    //}


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

                if (iniciativa.data_aprovacao != null)
                {
                    cmd.Parameters.AddWithValue("@dt_aprovacao", iniciativa.data_aprovacao);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_aprovacao", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }

                if (iniciativa.data_piloto != null)
                {
                    cmd.Parameters.AddWithValue("@dt_piloto", iniciativa.data_piloto);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_piloto", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }

                if (iniciativa.data_plenouso != null)
                {
                    cmd.Parameters.AddWithValue("@dt_plenouso", iniciativa.data_plenouso);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_plenouso", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }

                if (iniciativa.data_comunicacao != null)
                {
                    cmd.Parameters.AddWithValue("@dt_comunicacao", iniciativa.data_comunicacao);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@dt_comunicacao", SqlDbType.DateTime).Value = SqlDateTime.Null;
                }


                cmd.Parameters.AddWithValue("@id_esteira", iniciativa.id_esteira);
                cmd.Parameters.AddWithValue("@id_farol", iniciativa.id_farol);
                cmd.Parameters.AddWithValue("@id_etapa", iniciativa.id_etapa);
                cmd.Parameters.AddWithValue("@CPF", iniciativa.CPF);
                cmd.Parameters.AddWithValue("@id_CETI", iniciativa.id_ceti);
                cmd.Parameters.AddWithValue("@id_mega", iniciativa.id_mega);
                cmd.Parameters.AddWithValue("@TF_versao_agencia", iniciativa.TF_versao_agencia);
                cmd.Parameters.AddWithValue("@TF_versao_PA ", iniciativa.TF_versao_PA);
                cmd.Parameters.AddWithValue("@responsavel_neg", iniciativa.responsavel_neg);
                cmd.Parameters.AddWithValue("@responsavel_DS", iniciativa.responsavel_DS);
                cmd.Parameters.AddWithValue("@usabilidade", iniciativa.usabilidade);
                cmd.Parameters.AddWithValue("@beneficio_iniciativa", iniciativa.beneficio_iniciativa);
                cmd.Parameters.AddWithValue("@resumo_iniciativa", iniciativa.resumo_iniciativa);
                cmd.Parameters.AddWithValue("@id_jornada", iniciativa.id_jornada);
                cmd.Parameters.AddWithValue("@id_replanejamento", iniciativa.id_replanejamento);
                cmd.Parameters.AddWithValue("@id_visita", iniciativa.id_visita);
                //cmd.Parameters.AddWithValue("@id_origem", iniciativa.id_origem);
                //cmd.Parameters.AddWithValue("@id_dt", iniciativa.id_dt);


                //cmd.Parameters.AddWithValue("@id_canal", iniciativa.id_canal);
                //cmd.Parameters.AddWithValue("@id_comissao_varejo", iniciativa.id_comissao_varejo);

                //cmd.Parameters.AddWithValue("@VPL", iniciativa.VPL);
                //cmd.Parameters.AddWithValue("@id_orcamento", iniciativa.id_orcamento);
                //cmd.Parameters.AddWithValue("@esteira", iniciativa.Esteira);

                cmd.ExecuteNonQuery();


            }
        }

    }
}