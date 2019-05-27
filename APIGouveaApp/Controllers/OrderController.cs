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
        public HttpResponseMessage GetOrderByNumber([FromUri] string numberOrder)
        {
            List<ItemOrder> itensOrder = Persistencia.DD.OrderDD.GetOrderByNumber(numberOrder);
            for (int i = 0; i < itensOrder.Count - 1; i++)
            {
                ItemOrder itemTarget = itensOrder[i];
                Persistencia.DD.OrderDD.GetItemBarcode(ref itemTarget);
                Persistencia.DD.OrderDD.GetItemDescription(ref itemTarget);
            }
            ListItemOrder listItemOrder = new ListItemOrder();
            listItemOrder.listItemOder = itensOrder;
            return Request.CreateResponse(HttpStatusCode.OK, listItemOrder);
        }
    }
}