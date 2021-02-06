using Logic.Model;
using Microsoft.EntityFrameworkCore;

namespace Logic.Db
{
    public interface IInvoiceContext
    {
        DbSet<InvoiceItem> InvoiceItems { get; set; }
        DbSet<Invoice> Invoices { get; set; }
        int SaveChanges();
    }
}