﻿using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Relacionamentos_DAL
    {

        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        string proc = "producao.UP_Controle_Projetos_Oper_M_Relacionamentos";

        public bool RelacionamentoOrcamentoProjeto(int idProjeto, int idOrcamento)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

            using (con)
            {

                SqlCommand cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Relacionamentos", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@OPER", "I");
                cmd.Parameters.AddWithValue("@IdUm", idProjeto);
                cmd.Parameters.AddWithValue("@IdDois", idOrcamento);
                //cmd.Parameters.AddWithValue("@cod_orcamento", "cod_orcamento");
                //cmd.Parameters.AddWithValue("@id_iniciativa", "id_iniciativa");

                cmd.Parameters.AddWithValue("@Tabela", "producao.TB_Controle_Projetos_Projeto_Orcamento");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
        }

        public bool RelacionamentosProjetoComListas(int idProjeto, List<int> ids, string tabelapath, List<Etapa> etapas, List<Canal> canais)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

            var tabela = "producao.TB_Controle_Projetos_Projeto_" + tabelapath;


            StringBuilder query = new StringBuilder();

            if (tabelapath != "Etapas" && tabelapath != "Canais")
            {
                foreach (var item in ids)
                {
                    query.Append("insert into " + tabela + " values(" + idProjeto + ", " + item + ")");
                    query.Append("\n");
                }
            }
            else if (tabelapath == "Etapas")
            {
                foreach (var item in etapas)
                {

                    var dtinicio = item.dt_inicio != null ? item.dt_inicio.Value.ToString("yyyy-MM-dd") : null;
                    var dtfim = item.dt_fim != null ? item.dt_fim.Value.ToString("yyyy-MM-dd") : null;


                    query.Append("insert into " + tabela + " values(" + idProjeto + ", " + item.Id_Etapa + ", " + " ' " + dtinicio + " ' " + ", " + " ' " + dtfim + " ' " + "  )");
                    query.Append("\n");
                }
            }
            else if (tabelapath == "Canais") {
                foreach (var item in canais)
                {
                    var dtinicio = item.Data_Canal != null ? item.Data_Canal.Value.ToString("yyyy-MM-dd") : null;
                    //var dtfim = item.dt_fim != null ? item.dt_fim.Value.ToString("yyyy-MM-dd") : null;                    
                    query.Append("insert into " + tabela + " values(" + idProjeto + ", " + item.Id_Canal + ", " + " ' " + dtinicio + " ' " + ")");
                    query.Append("\n");
                }
            }


            using (con)
            {
                SqlCommand cmd = new SqlCommand(proc, con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OPER", tabelapath);
                cmd.Parameters.AddWithValue("@IdUm", idProjeto);
                cmd.Parameters.AddWithValue("@Tabela", tabela);
                cmd.Parameters.AddWithValue("@String", query.ToString());
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
        }




        public bool DeletaRelacionamento(int idProjeto, string tabela, string campo)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

            try
            {

                StringBuilder query = new StringBuilder();

                query.Append("delete from TB_Controle_Projetos_" + tabela + " where " + campo + "= " + idProjeto + "");

                using (con)
                {
                    SqlCommand cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Relacionamentos", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OPER", "Deleta");
                    cmd.Parameters.AddWithValue("@String", query.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                var execp = ex;
                return false;
            }

        }

        public List<Checkados> BuscaCheckadas(int? id_iniciativa, string tabelapath, string campo, string campoRetorno, string dataRetornoInicio, string dataRetornoFim)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

            List<Checkados> checkadas = new List<Checkados>();
            var oper = dataRetornoInicio != null ? "checkCDatas" : "checkados";
            var tabela = "producao.TB_Controle_Projetos_Projeto_" + tabelapath;

            StringBuilder query = new StringBuilder();
            query.Append("select * from " + tabela + " where " + campo + "= " + id_iniciativa + "");
            query.Append("\n");

            using (con)
            {
                SqlCommand command = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Relacionamentos", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IdUm", id_iniciativa);
                command.Parameters.AddWithValue("@oper", oper);
                command.Parameters.AddWithValue("@String", query.ToString());

                if (tabelapath == "etapas")
                {
                    con.Open();
                    using (SqlDataReader sdr = command.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            checkadas.Add(new Checkados
                            {
                                id_checkado = Convert.ToInt32(sdr[campoRetorno]),
                                dt_Inicio = sdr[dataRetornoInicio] != DBNull.Value ? Convert.ToDateTime(sdr[dataRetornoInicio]) : (DateTime?)null,
                                dt_Fim = sdr[dataRetornoFim] != DBNull.Value ? Convert.ToDateTime(sdr[dataRetornoFim]) : (DateTime?)null,
                            });
                        }
                    }
                }
                else if (tabelapath == "canais")
                {
                    con.Open();
                    using (SqlDataReader sdr = command.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            checkadas.Add(new Checkados
                            {
                                id_checkado = Convert.ToInt32(sdr[campoRetorno]),
                                dt_Inicio = sdr[dataRetornoInicio] != DBNull.Value ? Convert.ToDateTime(sdr[dataRetornoInicio]) : (DateTime?)null,
                                //dt_Fim = sdr[dataRetornoFim] != DBNull.Value ? Convert.ToDateTime(sdr[dataRetornoFim]) : (DateTime?)null,
                            });
                        }
                    }

                }
                else
                {
                    con.Open();
                    using (SqlDataReader sdr = command.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            checkadas.Add(new Checkados
                            {
                                id_checkado = Convert.ToInt32(sdr[campoRetorno])
                                //dt_Inicio = sdr[dataRetornoInicio] != DBNull.Value ? Convert.ToDateTime(sdr[dataRetornoInicio]) : (DateTime?)null,
                                //dt_Fim = sdr[dataRetornoFim] != DBNull.Value ? Convert.ToDateTime(sdr[dataRetornoFim]) : (DateTime?)null,
                            });
                        }
                    }
                }

                con.Close();
            }
            return checkadas;

        }

    }
}