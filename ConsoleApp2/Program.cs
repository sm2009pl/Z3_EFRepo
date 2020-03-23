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
            using var baza = new NorthwindContext();
            baza.Database.EnsureCreated();

            string idCust = "BONAP";

            var customers = baza.Customers.Where(x => x.CustomerId == idCust).ToList();
            var order = baza.Orders.Where(x => x.CustomerId == idCust).ToList();
            var ordersDetails = baza.OrderDetails.ToList();
            var products = baza.Products.ToList();


            var finalQuery =
                from c in customers
                join o in order on c.CustomerId equals o.CustomerId into tab1
                from t1 in tab1.ToList()
                join oD in ordersDetails on t1.OrderId equals oD.OrderId into tab2
                from t2 in tab2.ToList()
                join p in products on t2.ProductId equals p.ProductId into tabFinal
                from x in tabFinal.ToList()
                select new
                {
                    ClientId = c.CustomerId,
                    OrdId = t1.OrderId,
                    ProdId = x.ProductId,
                    ProdName = x.ProductName
                };
            foreach (var item in finalQuery)
            {
                Console.WriteLine("{0},  {1},  {2},  {3}", item.ClientId, item.OrdId, item.ProdId, item.ProdName);
            }
            Console.WriteLine("xxx");

        }
    }
}
