using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Z3_RE_EF.Models;
using System.Linq;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string id = "ALFKI";
            using var baza = new NorthwindContext();
            baza.Database.EnsureCreated();


            var client = baza.Customers.Where(x => x.CustomerId == id)
            .SelectMany(x => x.Orders)
            .Select(x => new
            {
                K1 = x.CustomerId,
                K2 = x.OrderId,
                K3 = x.OrderDetails.Select(x => x.ProductId).ToArray()
            });

            Console.WriteLine("Id klienta i nr zamowienia");
            Console.WriteLine("Id produktow");
            foreach (var item in client)
            {
                Console.WriteLine("{0},    {1}", item.K1 ,item.K2);
                foreach (var item2 in item.K3)
                {
                    Console.WriteLine("{0}", item2);
                }

            }
        }
    }
}
