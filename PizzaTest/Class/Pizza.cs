using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using PizzaTest.Models;
namespace PizzaTest.Class
{
    class Pizza
    {
        public static IEnumerable<PizzaModel.PizzaList> getString(string url)
        {
            IEnumerable<PizzaModel.PizzaList> reply = null;
            WebClient client = new WebClient();
            try { 
              reply = JsonConvert.DeserializeObject<IEnumerable<PizzaModel.PizzaList>>(client.DownloadString(url));
            } catch(Exception ex) {
                Console.WriteLine("Their was a error trying to get the list of pizzas!");
                Console.WriteLine(ex);
                return null;
            };
            return reply;
         }
    }
}
