using Microsoft.EntityFrameworkCore;
using PizzaShack.Entities;

namespace PizzaShack.Data
{
    public class PizzaContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Drink> Drinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //At some point you'll switch this out for an actual database
            optionsBuilder.UseSqlServer(@"
                Data Source=(localdb)\mssqllocaldb; 
                Initial Catalog=PizzaShack;
                Integrated Security=True");
        }
    }
}
