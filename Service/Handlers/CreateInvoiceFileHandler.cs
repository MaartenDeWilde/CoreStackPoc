using Messages;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Service.Handlers
{
    public class CreateInvoiceFileHandler : IHandleMessages<CreateInvoiceFile>
    {
        public Task Handle(CreateInvoiceFile message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
