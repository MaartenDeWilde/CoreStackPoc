using Logic.Db;
using Logic.Model;
using System;
using System.Collections.Generic;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new InvoiceContext())
            {
                var invoice = new Invoice
                {
                    Customer = "Somecustomer2",
                    Items = new List<InvoiceItem>
                    {
                       new InvoiceItem
                       {
                           Name = "Do stuff",
                           Price = 500M
                       }
                    }
                };
                context.Invoices.Add(invoice);
                context.SaveChanges();
            }
        }
    }
}
