using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructoraUdeC.Controllers
{
    public class BaseController : Controller
    {
        public bool verificarSesion()
        {
            return Session.Count > 0;
        }
    }
}