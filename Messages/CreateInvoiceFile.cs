using NServiceBus;
using System;

namespace Messages
{
    public class CreateInvoiceFile : IMessage
    {
        public int InvoiceId { get; set; }
    }
}
