using ConstructoraUdeC.Mapper.ParametersModule;
using ConstructoraUdeC.Models.ParametersModule;
using ConstructoraUdeCController.Implementation.ParametersModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructoraUdeC.Controllers
{
    public class HomeController : Controller
    {
        private ProjectImpController capaNegocio = new ProjectImpController();
        public ActionResult Index()
        {
            ProjectModelMapper mapper = new ProjectModelMapper();
            IEnumerable<ProjectModel> modelo = mapper.MapperT1T2(capaNegocio.RecordList(String.Empty).ToList());

            return View(modelo);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}