using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomaBack.BLL;
using DiplomaBack.BLL.BusinessModels;
using DiplomaBack.DAL.Entities.Order;
using DiplomaBack.DAL.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiplomaBack.Controllers
{
    [Produces("application/json")]
    [Route("api/Routes")]
    public class RoutesController : Controller
    {
        private readonly DataBaseContext _context;

        public RoutesController(DataBaseContext context)
        {
            _context = context;
        }
        // GET: api/Routes
        [HttpGet]
        public List<RouteInfo> Get()
        {
            List<OrderModel> orderModels = new List<OrderModel>
            {
                new OrderModel
                {
                    DeliveryAddress = "вулиця Сумська, 15"
                }
            };
            orderModels.AddRange(_context.Orders);
            var distanceList = new DistanceBuilderService().GetCourierRoute(GetRoutesFromOrders(orderModels), orderModels.Count);
            return distanceList;
        }


        private List<Route> GetRoutesFromOrders(List<OrderModel> orderModels)
        {
            var routes = new List<Route>();
            var counter = 0;
            while (counter != orderModels.Count)
            {
                for (int i = 0; i < orderModels.Count; i++)
                {
                    if (i == counter) continue;
                    routes.Add(new Route
                    {
                        From = orderModels[counter].DeliveryAddress,
                        To = orderModels[i].DeliveryAddress,
                    });
                }
                counter++;
            }
            return routes;
        }

        // GET: api/Routes/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Routes
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Routes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
