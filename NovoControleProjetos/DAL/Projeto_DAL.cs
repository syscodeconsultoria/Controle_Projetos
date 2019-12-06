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

    }

}