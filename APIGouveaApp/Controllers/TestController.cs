using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIGouveaApp.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage seila()
        {

            //Persistencia.AtividadeDD.executeSQL();
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}