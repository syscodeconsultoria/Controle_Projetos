using NovoControleProjetos.DAL;
using NovoControleProjetos.Models;
using NovoControleProjetos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class IniciativaController : Controller
    {
        DAL.Iniciativa_DAL iniciativa_DAL = new DAL.Iniciativa_DAL();
        OrcamentoController orcamentoController = new OrcamentoController();
        RelacionamentosController relacionamentosController = new RelacionamentosController();
        CetiController cetiController = new CetiController();
        JornadaController jornadaController = new JornadaController();
        ReplanejamentoController replanejamentoController = new ReplanejamentoController();
        FarolController farolController = new FarolController();
        VisitaController visitaController = new VisitaController();
        
        Mvp_DAL Mvp_DAL = new Mvp_DAL();


        // GET: Iniciativa
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(int id)
        {
            Iniciativa projeto = iniciativa_DAL.GetIniciativa(id);
            Orcamento orcamento = new Orcamento();
            projeto.orcamento = orcamento;

            return View(projeto);
        }

        [HttpPost]
        public ActionResult Create(Iniciativa iniciativa, Orcamento orcamento, List<Origem> origens, List<Etapa> etapas, List<Vertical> verticais,
                                  List<Canal> canais, Visita visita, Jornada jornada, Ceti ceti, Replanejamento replanejamento, Farol farol, Mvp mvp)
        {

            try
            {
                if (mvp != null)
                {
                    Mvp_DAL.InsereMvpNoBanco(mvp, iniciativa.Id_Iniciativa);
                }
                else
                {
                    return new HttpStatusCodeResult(404);
                }
                if (verticais != null)
                {
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, verticais.Select(x => x.Id_Vertical).ToList(), "Verticais", null, null);
                    if (!Ok)
                    {
                        return new HttpStatusCodeResult(404);
                    }
                }
                else
                {
                    bool Ok = relacionamentosController.DeletaRelacionamento(iniciativa.Id_Iniciativa, "projeto_verticais", "id_projeto");
                    if (!Ok)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }

                if (origens != null)
                {
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, origens.Select(x => x.Id_Origem).ToList(), "Origens", null, null);
                    if (!Ok)
                    {
                        return new HttpStatusCodeResult(404);
                    }
                }
                else
                {
                    bool Ok = relacionamentosController.DeletaRelacionamento(iniciativa.Id_Iniciativa, "projeto_origens", "id_projeto");
                    if (!Ok)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }

                if (etapas != null)
                {
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, null, "Etapas", etapas, null);
                    if (!Ok)
                    {
                        return new HttpStatusCodeResult(404);
                    }
                }
                else
                {
                    bool Ok = relacionamentosController.DeletaRelacionamento(iniciativa.Id_Iniciativa, "projeto_etapas", "id_projeto");
                    if (!Ok)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }


                if (canais != null)
                {
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, canais.Select(x => x.Id_Canal).ToList(), "Canais", null, canais);
                    if (!Ok)
                    {
                        return new HttpStatusCodeResult(404);
                    }
                }
                else
                {
                    bool Ok = relacionamentosController.DeletaRelacionamento(iniciativa.Id_Iniciativa, "projeto_canais", "id_projeto");
                    if (!Ok)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                }
              
                if (orcamento != null)
                {

                    orcamentoController.InsereOrcamento(orcamento, iniciativa.Id_Iniciativa);
                }

                if (jornada != null)
                {
                 iniciativa.id_jornada =  jornadaController.InsereJornada(jornada, iniciativa.Id_Iniciativa);
                }
         

                if (ceti.Data_Ceti != null || ceti.Total_Aprovado_Ceti != null || iniciativa.id_ceti != null)
                {
                    Ceti objCeti = new Ceti();
                    string oper = null;
                    if (iniciativa.id_ceti != null)
                    {
                        objCeti = cetiController.BuscaCeti(null, iniciativa.id_ceti);
                        oper = ceti.Data_Ceti != objCeti.Data_Ceti ? "I" : "U";
                    }                   
 
                   var id_ceti = cetiController.InsereCeti(ceti, iniciativa.Id_Iniciativa, iniciativa.id_ceti, oper ?? "I");

                    iniciativa.id_ceti = id_ceti;
                }

                if (replanejamento.data_replanejamento != null || replanejamento.motivo_replanejamento != null)
                {

                    Replanejamento objReplan = new Replanejamento();
                    string oper = null;
                    if (iniciativa.id_replanejamento != null)
                    {
                        objReplan = replanejamentoController.BuscaReplanejamento(null, iniciativa.id_replanejamento);
                        oper = replanejamento.data_replanejamento != objReplan.data_replanejamento ? "I" : "U";
                    }

                    iniciativa.id_replanejamento = replanejamentoController.InsereReplanejamento(replanejamento, iniciativa.Id_Iniciativa, iniciativa.id_replanejamento, oper ?? "I");
                                                         
                }               


                if (farol.Comentario_Farol != null)
                {
                    string oper = null;
                    Farol _farol = new Farol();

                    if (iniciativa.id_farol != null)
                    {
                        var objfarol = farolController.BuscaFarol(iniciativa.Id_Iniciativa, iniciativa.id_farol);
                        oper = objfarol.Id_Comentario_Farol != null ? "U" : "I";
                    }

                    farolController.InsereComentarioFarol(farol, iniciativa.Id_Iniciativa, iniciativa.id_farol, farol.Id_Comentario_Farol != null ? farol.Id_Comentario_Farol : null, oper);
                }

                if(visita.Data_Visita != null || visita.Cod_Agencia != null)
                {
                    string oper = null;
                    Visita _visita = new Visita();

                    if(iniciativa.id_visita != null)
                    {
                        var objVisita = visitaController.BuscaVisita(iniciativa.id_visita, null);
                        oper = objVisita.Data_Visita != visita.Data_Visita || objVisita.Cod_Agencia != visita.Cod_Agencia ? "I" : "U";
                    }

                    iniciativa.id_visita = visitaController.InsereVisita(visita, iniciativa.Id_Iniciativa, iniciativa.id_visita, oper ?? "I");

                }

                //iniciativa.id_orcamento = idOrcamento;
                //relacionamentosController.RelacionamentoOrcamentoProjeto(iniciativa.Id_Iniciativa, idOrcamento);          

                iniciativa_DAL.UpdateIniciativa(iniciativa);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {


                throw;
            }



        }


        public ActionResult BuscaIniciativa(int? id_iniciativa)
        {
            Iniciativa iniciativa = new Iniciativa();
            iniciativa = iniciativa_DAL.Buscainiciativa(id_iniciativa);

            return View(iniciativa);
        }

        public ActionResult _InsertIniciativa()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult _InsertIniciativa(string nome)
        {
            var id = iniciativa_DAL.RetornaIdIniciativa(nome);
            return Json(id, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditaIniciativa(int id)
        {
           
            Iniciativa iniciativa = iniciativa_DAL.Buscainiciativa(id);
           

         
            return View(iniciativa);
        }

        public ActionResult _DetalhesIniciativa(int? id_iniciativa, Replanejamento replanejamento)
        {

            ViewBag.id_Iniciativa = id_iniciativa;

            return PartialView(replanejamento);

        }

        public ActionResult ErroAmigavel()
        {
            return View();
        }
        /// <summary>
        /// Método para receber os dados da comboBox Da view Index na controller Home e com isso acionar a pagina de editar
        /// </summary>
        /// <param name="projetoEditarModelView"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditaProjeto(ProjetoEditarModelView projetoEditarModelView)
        {
            if (projetoEditarModelView.IdProjeto == 0)
            {
                return RedirectToAction("Index","Home");
            }
            Iniciativa iniciativa = iniciativa_DAL.Buscainiciativa(projetoEditarModelView.IdProjeto);
            ViewBag.NomeProjeto = iniciativa.nome_iniciativa;
            return View(nameof(EditaIniciativa), iniciativa);
        }
    }
}

