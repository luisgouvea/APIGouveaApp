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
            List<ItemOrder> itemnew = new List<ItemOrder>();
            for (int i = 0; i < itensOrder.Count; i++)
            {
                ItemOrder itemTarget = itensOrder[i];
                Persistencia.DD.OrderDD.GetItemBarcode(ref itemTarget);
                Persistencia.DD.OrderDD.GetItemDescription(ref itemTarget);
                itemnew.Add(itemTarget);
            }
            ListItemOrder listItemOrder = new ListItemOrder();
            listItemOrder.listItemOder = itemnew;
            return Request.CreateResponse(HttpStatusCode.OK, listItemOrder);
        }
    }
}