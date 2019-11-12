using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Relacionamentos_DAL
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);

        public bool RelacionamentoOrcamentoProjeto(int idProjeto, int idOrcamento)
        {
            using (con)
            {
                var cmd = new SqlCommand("producao.UP_Controle_Projetos_Cria_Relacionamento", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@OPER", "I");
                cmd.Parameters.AddWithValue("@IdUm", idProjeto);
                cmd.Parameters.AddWithValue("@IdDois", idOrcamento);
                //cmd.Parameters.AddWithValue("@cod_orcamento", "cod_orcamento");
                //cmd.Parameters.AddWithValue("@id_iniciativa", "id_iniciativa");

                cmd.Parameters.AddWithValue("@Tabela", "producao.TB_Controle_Projetos_Projeto_Orcamento");

                cmd.ExecuteNonQuery();

                return true;
            }
        }
    }
}