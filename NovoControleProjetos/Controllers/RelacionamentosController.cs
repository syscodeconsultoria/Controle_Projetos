using NovoControleProjetos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class RelacionamentosController : Controller
    {
        DAL.Relacionamentos_DAL relacionamentos_DAL = new DAL.Relacionamentos_DAL();

        // GET: Relacionamentos
        public ActionResult Index()
        {
            return View();
        }

        public bool RelacionamentoOrcamentoProjeto(int idProjeto, int idOrcamento)
        {

            relacionamentos_DAL.RelacionamentoOrcamentoProjeto(idProjeto, idOrcamento);

            return true;
        }

        public bool RelacionamentosProjetoComListas(int idProjeto, List<int> ids, string tabelapath, List<Etapa> etapas) {
            
            return relacionamentos_DAL.RelacionamentosProjetoComListas(idProjeto, ids, tabelapath, etapas != null ? etapas : null);
        }

        public bool RelacionamentosProjetoComListasVerticais(int idProjeto, List<int> ids, string tabelapath)
        {

            relacionamentos_DAL.RelacionamentosProjetoComListas(idProjeto, ids, tabelapath, null);

            return true;
        }

        public List<Checkados> BuscaCheckados(int? idProjeto, string tabelapath, string campo, string campoRetorno, string dataRetornoInicio, string dataRetornoFim) 
        {
            var checkados = relacionamentos_DAL.BuscaCheckadas(idProjeto, tabelapath, campo, campoRetorno, dataRetornoInicio, dataRetornoFim);
            //checkados.Select(x => x.dt_Inicio.Value.Date).ToList();
            return checkados;
        
        }

        public bool DeletaRelacionamento(int idProjeto, string tabela, string campo)
        {
            try
            {
                relacionamentos_DAL.DeletaRelacionamento(idProjeto, tabela, campo);
                
            }
            catch (Exception)
            {

                return false;
            }           

            return true;
        }


    }
}