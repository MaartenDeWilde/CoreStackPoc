using Logic.Db;
using Messages;
using NServiceBus;
using SpreadsheetLight;
using System.IO;
using System.Threading.Tasks;

namespace Service.Handlers
{
    public class CreateInvoiceFileHandler : IHandleMessages<CreateInvoiceFile>
    {
        public Task Handle(CreateInvoiceFile message, IMessageHandlerContext context)
        {
            using (var dataContext = new InvoiceContext())
            {
                var invoice = dataContext.Invoices.Find(message.InvoiceId);
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
