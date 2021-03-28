using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaTest.Models
{
    class PizzaModel
    {
        public class PizzaList
        {
            public IEnumerable<string> Toppings { get; set; }
        }


        public class PizzaRankingList
        {
            public string ToppingsString { get; set; }
            public int Count { get; set; }
        }
    }
}
