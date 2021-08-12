using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppEstamparia.Models;
using WebAppEstamparia.Repository;

namespace WebAppEstamparia.Controllers
{
    public class OperadorController : BaseController<Operador,OperadorRepository>
    {

        public OperadorController(): base(new OperadorRepository())
        {

        }
    }
}