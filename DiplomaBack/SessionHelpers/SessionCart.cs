using System;
using DiplomaBack.BLL.BusinessModels;
using DiplomaBack.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace DiplomaBack.SessionHelpers
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }
        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = ServiceProviderServiceExtensions.GetRequiredService<IHttpContextAccessor>(services)?.HttpContext.Session;
            SessionCart cart = session?.Get<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(DishModel product, int quantity)
        {
            base.AddItem(product, quantity);
            Session.Set("Cart", this);
        }

        public override void RemoveLine(DishModel product)
        {
            base.RemoveLine(product);
            Session.Set("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
