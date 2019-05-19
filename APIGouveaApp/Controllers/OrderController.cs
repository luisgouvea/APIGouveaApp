using Persistencia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIGouveaApp.Controllers
{
    public class OrderController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetOrderByNumber()
        {

            List<ItemOrder> itensOrder = Persistencia.DD.OrderDD.GetOrderByNumber("4009");
            for (int i = 0; i < itensOrder.Count - 1; i++)
            {
                ItemOrder itemTarget = itensOrder[i];
                Persistencia.DD.OrderDD.GetItemBarcode(ref itemTarget);
                Persistencia.DD.OrderDD.GetItemDescription(ref itemTarget);
            }
            return Request.CreateResponse(HttpStatusCode.OK, itensOrder);
        }
    }
}