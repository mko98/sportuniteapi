using System.Collections.Generic;
using SportUnite.Domain.Models;

namespace SportUnite.DAL
{
    public interface IInvoiceRepository
    {
        IEnumerable<Invoice> Invoices { get; }

        void DeleteInvoice(Invoice invoice);

        bool Save();

        void SaveInvoice(Invoice invoice);
    }
}


