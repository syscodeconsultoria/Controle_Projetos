using Newtonsoft.Json;
using NovoControleProjetos.DAL;
using NovoControleProjetos.Models;
using NovoControleProjetos.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
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
        Projeto_DAL Projeto_DAL = new Projeto_DAL();


        // GET: Iniciativa
        public ActionResult Index(bool teste)
        {
            ViewBag.Sucesso = teste;
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
                                  List<Canal> canais, Visita visita, Jornada jornada, Ceti ceti, Replanejamento replanejamento, Farol farol)
        {

            try
            {

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
                    iniciativa.id_jornada = jornadaController.InsereJornada(jornada, iniciativa.Id_Iniciativa);
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

                if (visita.Data_Visita != null || visita.Cod_Agencia != null)
                {
                    string oper = null;
                    Visita _visita = new Visita();

                    if (iniciativa.id_visita != null)
                    {
                        var objVisita = visitaController.BuscaVisita(iniciativa.id_visita, null);
                        oper = objVisita.Data_Visita != visita.Data_Visita || objVisita.Cod_Agencia != visita.Cod_Agencia ? "I" : "U";
                    }

                    iniciativa.id_visita = visitaController.InsereVisita(visita, iniciativa.Id_Iniciativa, iniciativa.id_visita, oper ?? "I");

                }

                //iniciativa.id_orcamento = idOrcamento;
                //relacionamentosController.RelacionamentoOrcamentoProjeto(iniciativa.Id_Iniciativa, idOrcamento);          

                iniciativa_DAL.UpdateIniciativa(iniciativa);

                return RedirectToAction("Index", "Home", true);
            }
            catch (Exception ex)
            {
                throw;
            }



        }
        [HttpPost]
        public JsonResult InsertMVP(string Mvp)
        {
            try
            {
                var mvpConvert = JsonConvert.DeserializeObject<List<Mvp>>(Mvp);
                Mvp_DAL.InsereMvpNoBanco(mvpConvert);
                ViewBag.Sucesso = true;
            }
            catch (Exception)
            {
                ViewBag.Sucesso = false;
            }

            return Json("Sucesso", JsonRequestBehavior.AllowGet);

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
        public ActionResult EditaIniciativa(int? id)
        {

            Iniciativa iniciativa = iniciativa_DAL.Buscainiciativa(id);

            return View(iniciativa);
        }


        /// <summary>
        /// Método para pegar os dados mvp e tratalos caso a data venha nula
        /// </summary>
        /// <param name="id_iniciativa"></param>
        /// <param name="replanejamento"></param>
        /// <returns></returns>
        public ActionResult _DetalhesIniciativa(int? id_iniciativa, Replanejamento replanejamento)
        {

            ViewBag.id_Iniciativa = id_iniciativa;
            ViewBag.MVP = Mvp_DAL.MvpsBuscaNoBanco(ViewBag.id_Iniciativa);
            int auxiliar = 0;
            int auxiliar2 = 0;
            int contador = 0;
            string[] dtConvertido;

            foreach (Mvp item in ViewBag.MVP)
            {

                if (item.Id_Iniciativa == 0 || item.Id_Iniciativa == null)
                {
                    auxiliar2++;
                }
                auxiliar++;
            }
            //Efetuando for para armazenar data convertida 
            dtConvertido = new string[auxiliar];
            foreach (Mvp item in ViewBag.MVP)
            {
                if (item.Dt_Mvp == null)
                {
                    item.Dt_Mvp = null;
                }
                else
                {
                    dtConvertido[contador] = item.Dt_Mvp.Value.ToShortDateString();
                }
                contador++;
            }
            ViewBag.dtConvertido = dtConvertido;

            if (auxiliar == auxiliar2)
            {
                ViewBag.acao = "criar";
            }

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
                return RedirectToAction("Index", "Home");
            }
            Iniciativa iniciativa = iniciativa_DAL.Buscainiciativa(projetoEditarModelView.IdProjeto);
            ViewBag.NomeProjeto = iniciativa.nome_iniciativa;
            return View(nameof(EditaIniciativa), iniciativa);
        }

        /// <summary>
        /// Método para listar todos os projetos
        /// </summary>
        /// <param name="pagina"></param>
        /// <returns></returns>
        public ActionResult ListaProjetos(int? pagina)
        {
            var Listas = Projeto_DAL.listaDeProjetos();
            if (TempData.ContainsKey("departamento"))
            {
                ViewBag.nomeDepartamento = TempData["departamento"].ToString();
            }
            return View(Listas);
        }
        /// <summary>
        /// Método para enviar dados de um projeto especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult DetalheProjeto(int id)
        {
            Iniciativa iniciativa = iniciativa_DAL.Buscainiciativa(id);
            ViewBag.IdIniciativa = iniciativa.Id_Iniciativa;
            ViewBag.NomeProjeto = iniciativa.nome_iniciativa;
            return View(iniciativa);
        }

        [HttpPost]
        public ActionResult PesquisaPorDepartamento(string Nome)
        {
            if (Nome == null || Nome == "")
            {
                var todoProjetos = Projeto_DAL.listaDeProjetos();
                return View(nameof(ListaProjetos), todoProjetos);
            }
            else
            {
                TempData["departamento"] = Nome;
                var lista = Projeto_DAL.listaProjetosNomeDepartamento(Nome);
                return View(nameof(ListaProjetos), lista);
            }
        }
    }
}

