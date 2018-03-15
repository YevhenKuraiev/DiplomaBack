using DiplomaBack.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DiplomaBack.BLL.BusinessModels
{
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();

        public virtual void AddItem(DishModel dish, int quantity)
        {
            var cartLine = _lineCollection.FirstOrDefault(g => g.Dish.Id == dish.Id);

            if (cartLine == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Dish = dish,
                    Quantity = quantity
                });
            }
            else
            {
                cartLine.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(DishModel dish)
        {
            _lineCollection.RemoveAll(l => l.Dish.Id == dish.Id);
        }

        public virtual double ComputeTotalValue()
        {
            return _lineCollection.Sum(e => e.Dish.Price * e.Quantity);

        }
        public virtual void Clear()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines => _lineCollection;
    }

    public class CartLine
    {
        public DishModel Dish { get; set; }
        public int Quantity { get; set; }
    }
}
