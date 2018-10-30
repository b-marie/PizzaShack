using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PizzaShack.Business;
using PizzaShack.Data;
using PizzaShack.Entities;

namespace PizzaShack.Web.Controllers
{
    public class PizzasController : Controller
    {
        private readonly PizzaService _context;

        public PizzasController(PizzaService context)
        {
            _context = context;
        }

        // GET: Pizzas
        public ViewResult Index()
        {
            return View(_context.GetAllPizzas());
        }

        // GET: Pizzas/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View(_context.GetPizzaById(id));
        }

        // GET: Pizzas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pizzas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Create([Bind("Id,Name,Description,Price,Size")] Pizza pizza)
        {
            _context.CreatePizza(pizza);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pizzas/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            var pizza = _context.GetPizzaById(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

        // POST: Pizzas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,Size")] Pizza pizza)
        {
            if (id != pizza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.UpdatePizza(pizza);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaExists(pizza.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pizza);
        }

        // GET: Pizzas/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var pizza = _context.GetPizzaById(id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        // POST: Pizzas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pizza = _context.GetPizzaById(id);
            _context.RemovePizza(pizza);

            return RedirectToAction(nameof(Index));
        }

        private bool PizzaExists(int id)
        {
            if (_context.GetPizzaById(id) != null)
            {
                return true;
            }
            return false;
        }
    }
}
