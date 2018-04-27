using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomaBack.BLL;
using DiplomaBack.BLL.BusinessModels;
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
            //var orders = _context.Orders;
            //foreach (var order in orders)
            //{
            //    order.DeliveryAddress
            //}
            var list = new List<Route>();
            list.Add(new Route
            {
                From = "Харьков",
                To = "Киев"
            });
            list.Add(new Route
            {
                From = "Харьков",
                To = "Львов"
            });
            list.Add(new Route
            {
                From = "Харьков",
                To = "Одесса"
            });
            list.Add(new Route
            {
                From = "Харьков",
                To = "Донецк"
            });
            var result = new DistanceBuilder().GetRoutesWithDistance(list);
            return result;
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
