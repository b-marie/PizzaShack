using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PizzaShack.Data;
using PizzaShack.Entities;

namespace PizzaShack.Business
{
    class DrinkService
    {
        private readonly PizzaContext _context;

        public DrinkService(PizzaContext context)
        {
            _context = context;
        }

        public List<Drink> GetDrinks()
        {
            return _context.Drinks.ToList();
        }

        public Drink GetDrinkById(int id)
        {
            return _context.Drinks.Find(id);
        }

        public void AddDrink(Drink drink)
        {
            _context.Drinks.Add(drink);
            _context.SaveChanges();
        }

        public void UpdateDrink(Drink drink)
        {
            _context.Drinks.Update(drink);
            _context.SaveChanges();
        }

        public void RemoveDrink(Drink drink)
        {
            _context.Remove(drink);
            _context.SaveChanges();
        }
    }
}
