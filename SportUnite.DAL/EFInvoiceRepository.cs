using System.Collections.Generic;
using System.Linq;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public class EFInvoiceRepository : IInvoiceRepository
    {
        private AppEventEntityDbContext context;

        public EFInvoiceRepository(AppEventEntityDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Invoice> Invoices => context.Invoice;

        public void DeleteInvoice(Invoice invoice)
        {
            context.Invoice.Remove(invoice);
            context.SaveChanges();
        }

        public bool Save()
        {
            return context.SaveChanges() >= 0;
        }

        public void SaveInvoice(Invoice invoices)
        {
            if (invoices.InvoiceId == 0)
            {
                context.Invoice.Add(invoices);
            }
            else
            {
                Invoice dbEntry = context.Invoice.FirstOrDefault(p => p.InvoiceId == invoices.InvoiceId);
                if (dbEntry != null)
                {
                    dbEntry.Name = invoices.Name;
                    dbEntry.Availability = invoices.Availability;
                }
            }
            context.SaveChanges();
        }
    }
}