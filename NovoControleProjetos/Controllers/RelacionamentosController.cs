﻿using System;
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

        public bool RelacionamentosProjetoComListas(int idProjeto, List<int> ids, string tabelapath) {

            relacionamentos_DAL.RelacionamentosProjetoComListas(idProjeto, ids, tabelapath );

            return true;
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