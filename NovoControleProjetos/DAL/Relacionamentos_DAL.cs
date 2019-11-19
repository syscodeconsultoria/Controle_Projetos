using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace NovoControleProjetos.DAL
{
    public class Relacionamentos_DAL
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["NovoControleProjetos"].ConnectionString);
        readonly string proc = "producao.UP_Controle_Projetos_Oper_M_Relacionamentos";

        public bool RelacionamentoOrcamentoProjeto(int idProjeto, int idOrcamento)
        {
            using (con)
            {

                var cmd = new SqlCommand(proc, con);
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

        public bool RelacionamentosProjetoComListas(int idProjeto, List<int> ids, string tabelapath)
        {
            var tabela = "producao.TB_Controle_Projetos_Projeto_" + tabelapath;

            try
            {
                StringBuilder query = new StringBuilder();
                foreach (var item in ids)
                {                    
                    query.Append("insert into " + tabela + " values(" + idProjeto + ", " + item + ")");
                    query.Append("\n");
                }

                using (con)
                {
                    var cmd = new SqlCommand(proc, con);
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
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeletaRelacionamento(int idProjeto, string tabela, string campo)
        {
            try
            {

                StringBuilder query = new StringBuilder();
                                                
                query.Append("delete from Tb_Controle_Projetos_" + tabela + " where " + campo + "= " + idProjeto + "");
                
                using (con)
                {
                    var cmd = new SqlCommand(proc, con);
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
                return false;
            }

        }
    }
}