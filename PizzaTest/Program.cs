using System;
using PizzaTest.Models;
using PizzaTest.Class;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<PizzaModel.PizzaRankingList> pizzaRanking = new List<PizzaModel.PizzaRankingList>(); ;
            IEnumerable<PizzaModel.PizzaList> pizzaList = Pizza.getString("https://www.brightway.com/CodeTests/pizzas.json");
            foreach(var pizza in pizzaList)
            {
               List<string> allToppingsList = new List<string>();
                foreach(string topping in pizza.Toppings)
                {
                    allToppingsList.Add(topping);
                }
                var orderToppings = allToppingsList.OrderBy(x => x);
                string orderstring = string.Join(",", orderToppings);
                var ToppingInList = pizzaRanking.Where(x => x.ToppingsString == orderstring);
                if (ToppingInList.Any())
                {
                    foreach (var item in ToppingInList.Where(x => x.ToppingsString == orderstring))
                    {
                        item.Count = item.Count + 1;
                    }
                }
                else 
                {
                    pizzaRanking.Add(new PizzaModel.PizzaRankingList { ToppingsString = orderstring, Count = 1 });
                }


            }
            var topList = pizzaRanking.OrderByDescending(x => x.Count).Take(20);
            foreach(var Toppie in topList)
            {
                Console.WriteLine("Toppings: "+Toppie.ToppingsString + " Count:" + Toppie.Count );
            }
            Console.ReadLine();
        }
    }
}
