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
                                  List<Canal> canais, Visita visita, Jornada jornada, Ceti ceti, Replanejamento replanejamento)
        {

            try
            {

                if (verticais != null)
                {
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, verticais.Select(x => x.Id_Vertical).ToList(), "Verticais", null);
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
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, origens.Select(x => x.Id_Origem).ToList(), "Origens", null );
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
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, null, "Etapas", etapas );
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
                    bool Ok = relacionamentosController.RelacionamentosProjetoComListas(iniciativa.Id_Iniciativa, canais.Select(x => x.Id_Canal).ToList(), "Canais", null);
                    if (Ok)
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


                //int idOrcamento = 
                if (orcamento != null) { 
                 
                    orcamentoController.InsereOrcamento(orcamento, iniciativa.Id_Iniciativa);
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
            return Json(id,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditaIniciativa(int id)
        {
           
            Iniciativa iniciativa = iniciativa_DAL.Buscainiciativa(id);           

         
            return View(iniciativa);
        }

        public ActionResult _DetalhesIniciativa(int? id_iniciativa)
        {
            
            ViewBag.id_Iniciativa = id_iniciativa;
            
            return PartialView();

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
            ViewBag.NomeProjeto = projetoEditarModelView.NomeProjeto;
            return View(nameof(EditaIniciativa), iniciativa);
        }
    }
}

