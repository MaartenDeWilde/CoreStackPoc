using Logic.Db;
using Logic.Model;
using MassTransit;
using Messages;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly IBus _bus;

        public InvoiceController(IBus bus)
        {
            this._bus = bus;
        }

        [HttpGet, Route("generate")]
        public async void Generate()
        {
            using (var ctx = new InvoiceContext())
            {
                var invoice = new Invoice() { Customer = "Test" };
                ctx.Invoices.Add(invoice);
                ctx.SaveChanges();

                await _bus.Publish(new CreateInvoiceFile() { InvoiceId = invoice.Id });
            }
        }

        [HttpGet, Route("download/{invoiceId}")]
        public IActionResult Download(int invoiceId)
        {
            using (var ctx = new InvoiceContext())
            {
                var file = ctx.Invoices.Find(invoiceId).File;
                var ms = new MemoryStream(file);
                return new FileStreamResult(ms, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                {
                    FileDownloadName = "Invoice.xlsx"
                };
            }
        }
    }
}
