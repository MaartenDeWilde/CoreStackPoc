using Logic.Db;
using Microsoft.Extensions.DependencyInjection;

namespace Logic.DI
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<IInvoiceContext, InvoiceContext>();
        }
    }
}
