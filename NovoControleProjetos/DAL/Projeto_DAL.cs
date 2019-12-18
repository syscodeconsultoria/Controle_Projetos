using NovoControleProjetos.Models;
using NovoControleProjetos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Projeto_DAL
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

        /// <summary>
        /// Método para pegar o nome e id do projeto dentro do banco de dados com isso populando a 
        /// combo da modal que será chamada na view Index na Home
        /// </summary>
        /// <returns></returns>
        public List<ProjetoEditarModelView> ListaProjetosParaCombo(int parametro)
        {
            var projetos = new List<ProjetoEditarModelView>();


            var cmd = new SqlCommand("producao.UP_Controle_Projetos_Oper_M_Iniciativa", con);

            cmd.Parameters.AddWithValue("@Oper", parametro);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                projetos.Add(new ProjetoEditarModelView
                {
                    IdProjeto = int.Parse(reader["id_iniciativa"].ToString()),
                    NomeProjeto = reader["nome_iniciativa"].ToString()
                });
            }
            con.Close();
            return projetos;
        }

        /// <summary>
        /// Lista para retornar lista de todos os projetos juntamente com o setor
        /// </summary>
        /// <returns></returns>
        public List<ListaDeProjetosModelView> listaDeProjetos()
        {
            List<ListaDeProjetosModelView> listas = new List<ListaDeProjetosModelView>();
            using (con)
            {
                try
                {
                    var cmd = new SqlCommand("UP_Controle_Projetos_Lista_Iniciativas", con);
                    cmd.Parameters.AddWithValue("@tipo_operacao", 1);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    var dados = cmd.ExecuteReader();
                    while (dados.Read())
                    {
                        listas.Add(new ListaDeProjetosModelView
                        {
                            DtAprovacao = DateTime.Parse(dados["dt_aprovacao"].ToString()),
                            IdIniciativa = int.Parse(dados["id_iniciativa"].ToString()),
                            NomeDepartamento = dados["ds_departamento"].ToString(),
                            NomeIniciativa = dados["nome_iniciativa"].ToString()
                        });
                    }
                    return listas;
                }
                catch (Exception e)
                {

                    throw;
                }

            }
        }


        /// <summary>
        /// Lista para retornar lista de todos os projetos juntamente com o setor passando o nome do setor como parametro
        /// </summary>
        /// <returns></returns>
        public List<ListaDeProjetosModelView> listaProjetosNomeDepartamento(string nomeDepartamento)
        {
            List<ListaDeProjetosModelView> listas = new List<ListaDeProjetosModelView>();
            using (con)
            {
                try
                {
                    var cmd = new SqlCommand("UP_Controle_Projetos_Lista_Iniciativas", con);
                    cmd.Parameters.AddWithValue("@nome_departamento", nomeDepartamento);
                    cmd.Parameters.AddWithValue("@tipo_operacao", 2);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    var dados = cmd.ExecuteReader();
                    while (dados.Read())
                    {
                        listas.Add(new ListaDeProjetosModelView
                        {
                            DtAprovacao = DateTime.Parse(dados["dt_aprovacao"].ToString()),
                            IdIniciativa = int.Parse(dados["id_iniciativa"].ToString()),
                            NomeDepartamento = dados["ds_departamento"].ToString(),
                            NomeIniciativa = dados["nome_iniciativa"].ToString()
                        });
                    }
                    return listas;
                }
                catch (Exception e)
                {

                    throw;
                }

            }
        }
    }

}