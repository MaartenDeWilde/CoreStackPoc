using Logic.Db;
using MassTransit;
using Messages;
using SpreadsheetLight;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Service.Handlers
{
    public class CreateInvoiceFileConsumer : IConsumer<CreateInvoiceFile>
    {
        public Task Consume(ConsumeContext<CreateInvoiceFile> context)
        {
            using (var dataContext = new InvoiceContext())
            {
                var invoice = dataContext.Invoices.Find(context.Message.InvoiceId);
                var memoryStream = new MemoryStream();
                using (var document = new SLDocument())
                {
                    document.SetCellValue("A1", invoice.Customer);
                    document.SaveAs(memoryStream);
                }
                memoryStream.Position = 0;
                invoice.File = memoryStream.ToArray();
                dataContext.SaveChanges();
            }
            return Task.CompletedTask;
        }

    
    }
}
