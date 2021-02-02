using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Model
{
    public class Invoice
    {
        public string Number { get; set; }

        public string Customer { get; set; }

        public virtual ICollection<InvoiceItem> Items { get; set; }

    }

    public class InvoiceItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
