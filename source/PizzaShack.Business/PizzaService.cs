using System.Collections.Generic;
using System.Linq;
using PizzaShack.Data;
using PizzaShack.Entities;

namespace PizzaShack.Business
{
    public class PizzaService
    {
        private readonly PizzaContext _context;

        public PizzaService(PizzaContext context)
        {
            _context = context;
        }

        public void CreatePizza(Pizza pizza)
        {
            //Do whatever business work is needed

            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }

        public List<Pizza> GetAllPizzas()
        {
            return _context.Pizzas.ToList();
        }

        public Pizza GetPizzaById(int id)
        {
            return _context.Pizzas.Find(id);
        }

        public void UpdatePizza(Pizza pizza)
        {
           _context.Pizzas.Update(pizza);
           _context.SaveChanges();
        }

        public void RemovePizza(Pizza pizza)
        {
            _context.Pizzas.Remove(pizza);
            _context.SaveChanges();
        }

    }
}
