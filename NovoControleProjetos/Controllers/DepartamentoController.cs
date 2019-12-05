using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NovoControleProjetos.Controllers
{
    public class DepartamentoController : Controller
    {

        DAL.Departamento_DAL departamento_DAL = new DAL.Departamento_DAL();

        // GET: Departamento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _ListaDepartamentos(int? id_departamento)
        {
            var departamentos = departamento_DAL.ListaDepartamentos();
            ViewBag.departamentos = departamentos;
            ViewBag.id_departamento = id_departamento;
            return PartialView(departamentos);
        }
    }
}