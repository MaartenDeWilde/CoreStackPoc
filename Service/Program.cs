using Logic.Db;
using Logic.Model;
using System;

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
                    Customer = "Somecustomer"
                };
                context.Invoices.Add(invoice);
                context.SaveChanges();
            }
        }
    }
}
